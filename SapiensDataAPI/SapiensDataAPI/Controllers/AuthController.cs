using DotNetEnv;
using Microsoft.AspNetCore.Identity; // Import Identity namespace for user and role management
using Microsoft.AspNetCore.Mvc; // Import namespace for ASP.NET Core MVC functionality
using SapiensDataAPI.Dtos.Auth.Request; // Import the request DTOs for authentication
using SapiensDataAPI.Models; // Import the ApplicationUserModel for user-related actions
using SapiensDataAPI.Services.JwtToken; // Import the JwtTokenService for handling JWT tokens

namespace SapiensDataAPI.Controllers // Define the namespace for the AuthController
{
	[Route("api/[controller]")] // Define the route template for this controller
	[ApiController] // Mark this class as an API controller
	public class AuthController : ControllerBase // Inherit from ControllerBase for handling API requests
	{
		private readonly UserManager<ApplicationUserModel> _userManager; // Dependency injection for managing users
		private readonly IJwtTokenService _jwtTokenService; // Dependency injection for handling JWT token generation

		public AuthController(UserManager<ApplicationUserModel> userManager, IJwtTokenService jwtTokenService) // Constructor to inject the services
		{
			_userManager = userManager; // Initialize UserManager
			_jwtTokenService = jwtTokenService; // Initialize JwtTokenService
		}

		[HttpPost("register-user")] // Define an HTTP POST endpoint for registering a user
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto model) // Action method for user registration
		{
			if (!ModelState.IsValid) // Check if the model state is valid
				return BadRequest("Invalid registration details."); // Return bad request if validation fails

			var userExists = await _userManager.FindByNameAsync(model.Username); // Check if the username already exists
			if (userExists != null) // If user exists
				return Conflict("Username already exists."); // Return conflict response if username exists

			var emailExists = await _userManager.FindByEmailAsync(model.Email); // Check if the email is already in use
			if (emailExists != null) // If email exists
				return Conflict("Email is already in use."); // Return conflict response if email exists

			var user = new ApplicationUserModel // Create a new ApplicationUserModel instance
			{
				UserName = model.Username, // Set the username
				Email = model.Email, // Set the email
				FirstName = model.FirstName, // Set the first name
				LastName = model.LastName // Set the last name
			};

			// Create the user and hash the password
			var result = await _userManager.CreateAsync(user, model.Password); // Create the user with the provided password

			if (!result.Succeeded) // If user creation fails
				return BadRequest(result.Errors); // Return bad request with the errors

			Env.Load(".env");
			var googleDrivePath = Environment.GetEnvironmentVariable("GOOGLE_DRIVE_BEGINNING_PATH");
			if (googleDrivePath == null)
			{
				return StatusCode(500, "Google Drive path doesn't exist in .env file.");
			}

			var userFolderPath = Path.Combine(googleDrivePath, "SapiensCloud", "media", "user_data", user.UserName);

			if (!Directory.Exists(userFolderPath))
			{
				try
				{
					Directory.CreateDirectory(userFolderPath);
				}
				catch
				{
					return StatusCode(500, "Can't create directory.");
				}
			}

			// Assign 'NormalUser' role by default
			var roleResult = await _userManager.AddToRoleAsync(user, "NormalUser"); // Add the user to the 'NormalUser' role
			if (!roleResult.Succeeded) // If role assignment fails
				return BadRequest("Failed to assign role."); // Return bad request

			return Ok("User registered and assigned role successfully."); // Return success message on successful registration
		}

		[HttpPost("user-login")] // Define an HTTP POST endpoint for user login
		public async Task<IActionResult> Login([FromBody] LoginRequestDto model) // Action method for user login
		{
			if (!ModelState.IsValid) // Check if the model state is valid
				return BadRequest("Invalid login details. Please provide a valid username and password."); // Return bad request if validation fails

			var user = await _userManager.FindByNameAsync(model.Username); // Find the user by their username
			if (user == null) // If user does not exist
				return Unauthorized("Username does not exist."); // Return unauthorized response if username is not found

			if (!await _userManager.CheckPasswordAsync(user, model.Password)) // Check if the provided password is correct
				return Unauthorized("Incorrect password."); // Return unauthorized response if password is incorrect

			// Generate token using the JWT token service
			var token = await _jwtTokenService.GenerateToken(user); // Await the task for token generation

			if (string.IsNullOrEmpty(token)) // If token generation fails
				return StatusCode(500, "An error occurred while generating the token."); // Return internal server error

			var userRoles = await _userManager.GetRolesAsync(user); // Retrieve the roles assigned to the user
			return Ok(new { Token = token, Message = "Login successful." }); // Return success response with the token and roles
		}
	}
}