using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; // Import MVC functionalities
using Microsoft.EntityFrameworkCore; // Import EF Core functionalities for database operations
using SoftwareManagementAPI.Data.DbContextCs; // Import custom DbContext for database access
using SoftwareManagementAPI.Models; // Import custom software model

namespace SoftwareManagementAPI.Controllers // Define the namespace for this controller
{
    [ApiController] // Mark the class as an API controller
    [Route("api/[controller]")] // Define the route for the controller
    [Authorize(Roles = "Admin, NormalUser")]
    public class SoftwareController : ControllerBase // Inherit from ControllerBase for API functionality
    {
        private readonly SoftwareApiDbContext _context; // Declare database context
        private readonly ILogger<SoftwareController> _logger; // Declare logger service

        public SoftwareController(SoftwareApiDbContext context, ILogger<SoftwareController> logger) // Constructor with dependency injection
        {
            _context = context; // Assign context
            _logger = logger; // Assign logger
        }

        // GET: api/Software
        [HttpGet] // Define an HTTP GET endpoint to retrieve all software records
        public async Task<IActionResult> Index() // Method to fetch and return all software records
        {
            _logger.LogInformation("Fetching all software records."); // Log information
            var softwareList = await _context.Softwares.ToListAsync(); // Fetch all software records
            return Ok(softwareList); // Return all software records
        }

        // GET: api/Software/Details/5
        [HttpGet("{id}")] // Define an HTTP GET endpoint to retrieve software by ID
        public async Task<IActionResult> Details(int id) // Method to fetch and return software details by ID
        {
            _logger.LogInformation($"Fetching details for Software ID: {id}"); // Log information
            var software = await _context.Softwares.FindAsync(id); // Find the software by ID
            if (software == null) // Check if software is not found
            {
                _logger.LogWarning($"Software with ID {id} not found."); // Log warning
                return NotFound("Software not found."); // Return 404 if not found
            }
            return Ok(software); // Return the software details
        }

        // POST: api/Software/Create
        [HttpPost] // Define an HTTP POST endpoint to create new software
        public async Task<IActionResult> Create([FromBody] SoftwareModel software) // Method to create new software
        {
            if (software == null) // Check if software data is null
            {
                _logger.LogWarning("Invalid software data provided."); // Log warning
                return BadRequest("Invalid software data."); // Return bad request if data is invalid
            }

            if (!ModelState.IsValid) // Check if the model is not valid
            {
                _logger.LogWarning("Model validation failed."); // Log warning
                return BadRequest(ModelState); // Return bad request with model state errors
            }

            try
            {
                await _context.Softwares.AddAsync(software); // Add the new software record
                await _context.SaveChangesAsync(); // Save changes to the database
                _logger.LogInformation("Software created successfully."); // Log information
                return CreatedAtAction(nameof(Details), new { id = software.Id }, software); // Return 201 Created response
            }
            catch (DbUpdateException ex) // Catch database update exception
            {
                _logger.LogError(ex, "Error creating software."); // Log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating software."); // Return 500 error
            }
        }

        // PUT: api/Software/Edit/5
        [HttpPut("{id}")] // Define an HTTP PUT endpoint to edit software by ID
        public async Task<IActionResult> Edit(int id, [FromBody] SoftwareModel software) // Method to edit software
        {
            if (id != software.Id) // Check if ID in URL does not match ID in the body
            {
                _logger.LogWarning("Software ID mismatch."); // Log warning
                return BadRequest("ID mismatch."); // Return bad request for mismatch
            }

            if (!ModelState.IsValid) // Check if the model is not valid
            {
                _logger.LogWarning("Model validation failed."); // Log warning
                return BadRequest(ModelState); // Return bad request with model state errors
            }

            try
            {
                _context.Softwares.Update(software); // Update the software record
                await _context.SaveChangesAsync(); // Save changes to the database

                _logger.LogInformation($"Software with ID {id} updated successfully."); // Log success

                return Ok(new // Return success response
                {
                    Message = "Software updated successfully.", // Success message
                    Software = software  // Return the updated software object
                });
            }
            catch (DbUpdateConcurrencyException ex) // Catch concurrency exception
            {
                _logger.LogError(ex, $"Concurrency issue while updating Software ID: {id}."); // Log error
                return Conflict("Concurrency error occurred."); // Return conflict status for concurrency error
            }
            catch (DbUpdateException ex) // Catch database update exception
            {
                _logger.LogError(ex, "Error updating software."); // Log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating software."); // Return 500 error
            }
        }

        // DELETE: api/Software/Delete/5
        [HttpDelete("{id}")] // Define an HTTP DELETE endpoint to delete software by ID
        public async Task<IActionResult> Delete(int id) // Method to delete software by ID
        {
            _logger.LogInformation($"Deleting Software with ID: {id}"); // Log information
            var software = await _context.Softwares.FindAsync(id); // Find the software by ID
            if (software == null) // Check if software is not found
            {
                _logger.LogWarning($"Software with ID {id} not found."); // Log warning
                return NotFound("Software not found."); // Return 404 if not found
            }

            try
            {
                _context.Softwares.Remove(software); // Remove the software record
                await _context.SaveChangesAsync(); // Save changes to the database

                _logger.LogInformation($"Software with ID {id} deleted successfully."); // Log success

                return Ok(new // Return success response
                {
                    Message = "Software deleted successfully.", // Success message
                    Software = software  // Return the deleted software object
                });
            }
            catch (DbUpdateException ex) // Catch database update exception
            {
                _logger.LogError(ex, "Error deleting software."); // Log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting software."); // Return 500 error
            }
        }

        // DELETE: api/software/delete-by-name/{name}
        [HttpDelete("delete-by-name/{name}")] // Define an HTTP DELETE endpoint to delete software by name
        public async Task<IActionResult> DeleteByName(string name) // Method to delete software by name
        {
            _logger.LogInformation($"Deleting Software with name: {name}"); // Log information
            var software = await _context.Softwares.FirstOrDefaultAsync(s => s.Name == name); // Find software by name
            if (software == null) // Check if software is not found
            {
                _logger.LogWarning($"Software with name {name} not found."); // Log warning
                return NotFound("Software not found."); // Return 404 if not found
            }

            try
            {
                _context.Softwares.Remove(software); // Remove the software record
                await _context.SaveChangesAsync(); // Save changes to the database

                _logger.LogInformation($"Software with name {name} deleted successfully."); // Log success

                return Ok(new // Return success response
                {
                    Message = "Software deleted successfully.", // Success message
                    Software = software // Return the deleted software object
                });
            }
            catch (DbUpdateException ex) // Catch database update exception
            {
                _logger.LogError(ex, "Error deleting software."); // Log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting software."); // Return 500 error
            }
        }
    }
}