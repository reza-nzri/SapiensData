using Microsoft.AspNetCore.Authorization; // Import authorization functionalities
using Microsoft.AspNetCore.Mvc; // Import MVC functionalities

namespace SapiensDataAPI.Controllers // Define the namespace for this controller
{
    [ApiController] // Mark the class as an API controller
    [Route("api/[controller]")] // Define the route for the controller
    public class ProtectedController : ControllerBase // Inherit from ControllerBase for API functionality
    {
        /// <summary>
        /// Gets admin data accessible only to users with the "Admin" role.
        /// </summary>
        /// <returns>An Ok response with admin protected data.</returns>
        [HttpGet("admin-data")] // Define an HTTP GET endpoint for admin data
        [Authorize(Policy = "Admin")] // Access for users with "Admin" role
        public IActionResult GetAdminData() // Method to return admin-protected data
        {
            var response = new // Create the response object
            {
                Success = true, // Indicate success
                Message = "Access granted.", // Message to indicate access is granted
                Data = "This is admin protected data." // The admin-protected data
            };

            return Ok(response); // Return the response with a 200 OK status
        }

        /// <summary>
        /// Gets user data accessible only to normal users.
        /// </summary>
        /// <returns>An Ok response with user protected data.</returns>
        [HttpGet("user-data")] // Define an HTTP GET endpoint for normal user data
        [Authorize(Policy = "NormalUser")] // Access for users with "NormalUser" role
        public IActionResult GetUserData() // Method to return user-protected data
        {
            var response = new // Create the response object
            {
                Success = true, // Indicate success
                Message = "Access granted.", // Message to indicate access is granted
                Data = "This is user protected data." // The user-protected data
            };

            return Ok(response); // Return the response with a 200 OK status
        }

		[HttpGet("superadmin-data")] // Define an HTTP GET endpoint for normal user data
		[Authorize(Policy = "SuperAdmin")] // Access for users with "NormalUser" role
		public IActionResult GetSuperAdminData() // Method to return user-protected data
		{
			var response = new // Create the response object
			{
				Success = true, // Indicate success
				Message = "Access granted.", // Message to indicate access is granted
				Data = "This is SuperAdmin protected data." // The user-protected data
			};

			return Ok(response); // Return the response with a 200 OK status
		}

		/// <summary>
		/// Handle access denied for unauthorized users.
		/// </summary>
		/// <returns>A response with error message for unauthorized access.</returns>
		[HttpGet("unauthorized")] // Define an HTTP GET endpoint for unauthorized access
        public IActionResult HandleUnauthorizedAccess() // Method to handle unauthorized access
        {
            var response = new // Create the response object
            {
                Success = false, // Indicate failure
                Message = "Access denied. You do not have the necessary permissions to view this data.", // Error message
                Suggestion = "Please contact your administrator for more information." // Suggestion to resolve the issue
            };

            return Unauthorized(response); // Return the response with a 401 Unauthorized status
        }
    }
}