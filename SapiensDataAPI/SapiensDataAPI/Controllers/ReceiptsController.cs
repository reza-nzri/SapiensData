using AutoMapper;
using DotNetEnv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapiensDataAPI.Data.DbContextCs;
using SapiensDataAPI.Dtos;
using SapiensDataAPI.Dtos.Expense.Request;
using SapiensDataAPI.Dtos.ImageUploader.Request;
using SapiensDataAPI.Dtos.Income.Request;
using SapiensDataAPI.Dtos.Receipt.JSON;
using SapiensDataAPI.Dtos.Receipt.Request;
using SapiensDataAPI.Models;
using SapiensDataAPI.Services.JwtToken;
using System;
using System.Text.Json;

namespace SapiensDataAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReceiptsController(SapeinsDataContext context, IJwtTokenService jwtTokenService, IMapper mapper, UserManager<ApplicationUserModel> userManager) : ControllerBase
	{
		private readonly SapeinsDataContext _context = context;
		private readonly IJwtTokenService _jwtTokenService = jwtTokenService; // Dependency injection for handling JWT token generation
		private readonly IMapper _mapper = mapper;
		private readonly UserManager<ApplicationUserModel> _userManager = userManager;

		// GET: api/Receipts
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
		{
			return await _context.Receipts.ToListAsync();
		}

		// GET: api/Receipts
		[HttpPost("receive-json-from-python")]
		[Authorize]
		public async Task<IActionResult> ReceiveJSON([FromBody] ReceiptVailidation receiptVailidation)
		{
			var token = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
			var decodedToken = _jwtTokenService.DecodeJwtPayloadToJson(token).RootElement;
			JwtPayload? JwtPayload = JsonSerializer.Deserialize<JwtPayload>(decodedToken) ?? null;
			if (JwtPayload == null)
			{
				return BadRequest("JwtPayload is not ok.");
			}

			Env.Load(".env");
			var googleDrivePath = Environment.GetEnvironmentVariable("GOOGLE_DRIVE_BEGINNING_PATH");
			if (googleDrivePath == null)
			{
				return StatusCode(500, "Google Drive path doesn't exist in .env file.");
			}

			//var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SapiensCloud", "src", "media", "UserReceiptUploads", JwtPayload.Sub);
			var filePath = Path.Combine(googleDrivePath, "SapiensCloud", "media", "user_data", JwtPayload.Sub, "receipts", receiptVailidation.FileMetadata.SourceImage);
			if (!await Task.Run(() => System.IO.File.Exists(filePath)))
			{
				return BadRequest("File doesn't exist");
			}

			string? directory = Path.GetDirectoryName(filePath) ?? null;
			if (directory == null || !await Task.Run(() => Directory.Exists(directory)))
			{
				return BadRequest("Directory is not ok");
			}

			var correctedStoreName = receiptVailidation.Store.Name.Replace(' ', '-');

			var extension = Path.GetExtension(filePath);
			var newFileName = correctedStoreName + "_" + receiptVailidation.Receipt.BuyDatetime.ToString("yyyyMMdd_HHmmss") + extension;

			// Create the new path by combining the directory and new file name
			string newPath = Path.Combine(directory, newFileName);

			// Rename the file by moving it to the new path
			await Task.Run(() => System.IO.File.Move(filePath, newPath));

			var pathSegments = filePath.Split(Path.DirectorySeparatorChar);
			var lastThreeSegments = string.Join(Path.DirectorySeparatorChar.ToString(), pathSegments.TakeLast(3));

			var user = await _userManager.FindByNameAsync(JwtPayload.Sub);
			if (user == null)
			{
				// Handle the case where the user is not found
				return NotFound("User not found");
			}

			// Then use it in the LINQ query
			var receipts = await _context.Receipts
				.Where(r => r.ReceiptImagePath != null && r.ReceiptImagePath.EndsWith(lastThreeSegments) && r.UserId == user.Id)
				.ToListAsync();

			if (receipts.Count == 0)
			{
				return NotFound("No receipts found");
			}

			if (receipts.Count > 1)
			{
				return BadRequest($"Too many receipts, should be 1 but were {receipts.Count}");
			}

			receipts[0].ReceiptImagePath = newPath;

			await _context.SaveChangesAsync();

			return Ok("Image is ok");
		}

		// GET: api/Receipts/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Receipt>> GetReceipt(int id)
		{
			var receipt = await _context.Receipts.FindAsync(id);

			if (receipt == null)
			{
				return NotFound();
			}

			return receipt;
		}

		// PUT: api/Receipts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		[Authorize(Policy = "Admin")]
		public async Task<IActionResult> PutReceipt(int id, Receipt receipt)
		{
			if (id != receipt.ReceiptId)
			{
				return BadRequest();
			}

			_context.Entry(receipt).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ReceiptExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Receipts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostReceipt([FromForm] UploadImageDto image)
		{
			var token = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
			var decodedToken = _jwtTokenService.DecodeJwtPayloadToJson(token).RootElement;
			JwtPayload? JwtPayload = JsonSerializer.Deserialize<JwtPayload>(decodedToken) ?? null;
			if (JwtPayload == null)
			{
				return BadRequest("JwtPayload is not ok.");
			}

			if (image == null || image.Image.Length == 0)
				return BadRequest("No image file provided.");

			Env.Load(".env");
			var googleDrivePath = Environment.GetEnvironmentVariable("GOOGLE_DRIVE_BEGINNING_PATH");
			if (googleDrivePath == null)
			{
				return StatusCode(500, "Google Drive path doesn't exist in .env file.");
			}

			//var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SapiensCloud", "src", "media", "UserReceiptUploads", JwtPayload.Sub);
			var uploadsFolderPath = Path.Combine(googleDrivePath, "SapiensCloud", "media", "user_data", JwtPayload.Sub, "receipts");

			if (!Directory.Exists(uploadsFolderPath))
			{
				try
				{
					Directory.CreateDirectory(uploadsFolderPath);
				}
				catch
				{
					return StatusCode(500, "Can't create directory.");
				}
			}

			var extension = Path.GetExtension(image.Image.FileName);
			var newFileName = "to_process_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;

			var filePath = Path.Combine(uploadsFolderPath, newFileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await image.Image.CopyToAsync(fileStream);
			}

			var user = await _userManager.FindByNameAsync(JwtPayload.Sub);
			if (user == null)
			{
				return NotFound("User was not found.");
			}
			var userId = user.Id;

			var EXAMPLEReceiptDto = new ReceiptDto
			{
				BuyDatetime = DateTime.Now,
				TraceNumber = "ABC12345",
				TotalAmount = 150.00m,
				CashbackAmount = 5.00m,
				Currency = "USD",
				FullNamePaymentMethod = "Credit Card",
				Iban = "US12345678901234567890",
				ReceiptImagePath = filePath,
				UserId = userId
			};

			var receipt = _mapper.Map<Receipt>(EXAMPLEReceiptDto);
			_context.Receipts.Add(receipt);
			await _context.SaveChangesAsync();

			return Ok("Image uploaded successfully.");
		}

		// DELETE: api/Receipts/5
		[HttpDelete("{id}")]
		[Authorize(Policy = "Admin")]
		public async Task<IActionResult> DeleteReceipt(int id)
		{
			var receipt = await _context.Receipts.FindAsync(id);
			if (receipt == null)
			{
				return NotFound();
			}

			_context.Receipts.Remove(receipt);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ReceiptExists(int id)
		{
			return _context.Receipts.Any(e => e.ReceiptId == id);
		}
	}
}