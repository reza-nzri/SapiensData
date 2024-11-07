using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapiensDataAPI.Dtos;
using SapiensDataAPI.Dtos.ImageUploader.Request;
using SapiensDataAPI.Models;
using SapiensDataAPI.Services.JwtToken;
using System.Text.Json;

namespace SapiensDataAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReceiptsController : ControllerBase
	{
		private readonly SapeinsDataContext _context;
		private readonly IJwtTokenService _jwtTokenService; // Dependency injection for handling JWT token generation

		public ReceiptsController(SapeinsDataContext context, IJwtTokenService jwtTokenService)
		{
			_context = context;
			_jwtTokenService = jwtTokenService; // Initialize JwtTokenService
		}

		// GET: api/Receipts
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
		{
			return await _context.Receipts.ToListAsync();
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
		public async Task<ActionResult<Receipt>> PostReceipt([FromForm] UploadImageDto image)
		{
			var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
			var decodedToken = _jwtTokenService.DecodeJwtPayloadToJson(token).RootElement;
			JwtPayload JwtPayload = JsonSerializer.Deserialize<JwtPayload>(decodedToken) ?? new JwtPayload(); ;

			if (image == null || image.Image.Length == 0)
				return BadRequest("No image file provided.");

			var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "src", "media", "UserReceiptUploads", JwtPayload.Sub);

			if (!Directory.Exists(uploadsFolderPath))
				Directory.CreateDirectory(uploadsFolderPath);

			var extension = Path.GetExtension(image.Image.FileName);
			var newFileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;

			var filePath = Path.Combine(uploadsFolderPath, newFileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await image.Image.CopyToAsync(fileStream);
			}

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