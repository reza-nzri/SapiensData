using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapiensDataAPI.Models;
using System.IO;
using SapiensDataAPI.Dtos.ImageUploader.Request;

namespace SapiensDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly SapeinsDataContext _context;

        public ReceiptsController(SapeinsDataContext context)
        {
            _context = context;
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
            //var decodedToken = DecodeJwtPayloadToJson(token);

			if (image == null || image.Image.Length == 0)
                return BadRequest("No image file provided.");

            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "src", "media", "UserReceiptUploads", image.UserName);

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var filePath = Path.Combine(uploadsFolderPath, image.Image.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.Image.CopyToAsync(fileStream);
            }

            return Ok("Image uploaded successfully.");
        }

		private object DecodeJwtPayloadToJson(string token)
		{
			throw new NotImplementedException();
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
