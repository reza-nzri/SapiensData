using DotNetEnv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapiensDataAPI.Dtos.Auth.Request;
using SapiensDataAPI.Dtos.ImageUploader.Request;
using SapiensDataAPI.Dtos.Receipt.Request;
using SapiensDataAPI.Dtos;
using SapiensDataAPI.Models;
using SapiensDataAPI.Services.JwtToken;
using System.Data.Entity;
using System.Text.Json;
using AutoMapper;
using SapiensDataAPI.Data.DbContextCs;

namespace SapiensDataAPI.Controllers
{
	// Define the route for the controller and mark it as an API controller
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		// Dependency injection for UserManager, RoleManager, and IJwtTokenService
		private readonly UserManager<ApplicationUserModel> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IJwtTokenService _jwtTokenService;
		private readonly SapeinsDataContext _context;
		private readonly IMapper _mapper;

		// Constructor to initialize the injected services
		public AccountController(UserManager<ApplicationUserModel> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenService jwtTokenService, SapeinsDataContext context, IMapper mapper)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenService = jwtTokenService;
			_context = context;
			_mapper = mapper;
		}

		// Get all users and their roles
		[HttpGet("get-all-users")]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _userManager.Users.ToListAsync(); // Retrieve all users
			var usersWithRoles = new List<object>(); // Create a list to hold users with roles

			// Iterate through each user and retrieve their roles
			foreach (var user in users)
			{
				var roles = await _userManager.GetRolesAsync(user); // Get roles for the user

				// Create an anonymous object containing the user's details and roles
				var userWithRoles = new
				{
					user.FirstName,
					user.LastName,
					user.Id,
					user.UserName,
					user.NormalizedUserName,
					user.Email,
					user.NormalizedEmail,
					user.EmailConfirmed,
					user.PasswordHash,
					user.SecurityStamp,
					user.ConcurrencyStamp,
					user.PhoneNumber,
					user.PhoneNumberConfirmed,
					user.TwoFactorEnabled,
					user.LockoutEnd,
					user.LockoutEnabled,
					user.AccessFailedCount,
					Roles = roles.ToList() // Convert roles to a list
				};

				usersWithRoles.Add(userWithRoles); // Add the user with roles to the list
			}

			// Return the list of users with their roles
			return Ok(usersWithRoles);
		}

		// Get user by username
		[HttpGet("get-user-by-username/{username}")]
		public async Task<IActionResult> GetUserByUsername(string username)
		{
			// Validate input
			if (string.IsNullOrWhiteSpace(username))
			{
				return BadRequest(new
				{
					StatusCode = 400,
					Message = "Username cannot be empty."
				});
			}

			// Find user by username
			var user = await _userManager.FindByNameAsync(username);

			// Check if user exists
			if (user == null)
			{
				return NotFound(new
				{
					StatusCode = 404,
					Message = $"User with username '{username}' was not found."
				});
			}

			// Get roles for the user
			var roles = await _userManager.GetRolesAsync(user);

			// Construct user response with roles
			var userWithRoles = new
			{
				user.FirstName,
				user.LastName,
				user.Id,
				user.UserName,
				user.NormalizedUserName,
				user.Email,
				user.NormalizedEmail,
				user.EmailConfirmed,
				user.PhoneNumber,
				user.PhoneNumberConfirmed,
				user.TwoFactorEnabled,
				user.LockoutEnd,
				user.LockoutEnabled,
				user.AccessFailedCount,
				Roles = roles.ToList() // Convert roles to a list
			};

			// Return success response with user data
			return Ok(new
			{
				StatusCode = 200,
				Message = "User found successfully.",
				Data = userWithRoles
			});
		}

		// Admin deletes a user by username
		[HttpPost("upload-pfp")]
		[Authorize]
		public async Task<IActionResult> AdminDeleteUser([FromForm] UploadImageDto image)
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
			var uploadsFolderPath = Path.Combine(googleDrivePath, "SapiensCloud", "media", "user_data", JwtPayload.Sub);

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
			var newFileName = "profile-picture_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;

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

			user.ProfilePicturePath = filePath;
			_context.Update(user);
			await _context.SaveChangesAsync();

			return Ok("Image uploaded successfully.");
		}

		// Admin deletes a user by username
		[HttpDelete("admin/delete-user/{username}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AdminDeleteUser(string username)
		{
			var user = await _userManager.FindByNameAsync(username); // Find the user by username
			if (user == null)
				return NotFound($"User with username '{username}' not found."); // Return not found if user doesn't exist

			var result = await _userManager.DeleteAsync(user); // Attempt to delete the user
			if (result.Succeeded)
				return Ok("User deleted successfully."); // Return success if deletion is successful

			// Return any errors encountered during deletion
			return BadRequest(result.Errors.Select(e => e.Description));
		}

		// Allows a user to delete their own account
		[HttpDelete("delete-my-account")]
		public async Task<IActionResult> DeleteMyAccount([FromBody] string username)
		{
			var user = await _userManager.FindByNameAsync(username); // Find the user by username
			if (user == null)
				return NotFound("User not found."); // Return not found if user doesn't exist

			var result = await _userManager.DeleteAsync(user); // Attempt to delete the user
			if (result.Succeeded)
				return Ok("Your account has been deleted successfully."); // Return success if deletion is successful

			// Return any errors encountered during deletion
			return BadRequest(result.Errors.Select(e => e.Description));
		}

		// Deletes all users (function similar to an admin's action but without authorization required)
		[HttpDelete("public-like-admin/delete-all-users")]
		public async Task<IActionResult> DeleteAllUsers()
		{
			var users = _userManager.Users.ToList(); // Get all users

			// Iterate through each user and delete them
			foreach (var user in users)
			{
				var result = await _userManager.DeleteAsync(user); // Delete the user
				if (!result.Succeeded)
					return BadRequest($"Failed to delete user {user.UserName}"); // Return error if deletion fails
			}

			return Ok("All users deleted successfully."); // Return success after all users are deleted
		}

		// Admin updates a user by username
		[HttpPut("admin/update-user/{username}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AdminUpdateUser(string username, [FromBody] AdminUpdateUserDto model)
		{
			var user = await _userManager.FindByNameAsync(username); // Find the user by username
			if (user == null)
				return NotFound($"User with username '{username}' not found."); // Return not found if user doesn't exist

			// Update user properties based on input model
			user.UserName = model.Username;
			user.Email = model.Email;
			user.FirstName = model.FirstName;
			user.LastName = model.LastName;

			var updateResult = await _userManager.UpdateAsync(user); // Attempt to update the user
			if (!updateResult.Succeeded)
				return BadRequest($"Error updating user: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}"); // Return any errors

			// Handle password update if provided
			if (!string.IsNullOrEmpty(model.Password))
			{
				var passwordRemovalResult = await _userManager.RemovePasswordAsync(user); // Remove current password
				if (passwordRemovalResult.Succeeded)
				{
					var addPasswordResult = await _userManager.AddPasswordAsync(user, model.Password); // Add new password
					if (!addPasswordResult.Succeeded)
						return BadRequest($"Error setting password: {string.Join(", ", addPasswordResult.Errors.Select(e => e.Description))}"); // Return any errors
				}
				else
				{
					return BadRequest($"Error removing password: {string.Join(", ", passwordRemovalResult.Errors.Select(e => e.Description))}"); // Return any errors
				}
			}

			// Handle role update if provided
			if (!string.IsNullOrEmpty(model.Role))
			{
				var currentRoles = await _userManager.GetRolesAsync(user); // Get current roles
				await _userManager.RemoveFromRolesAsync(user, currentRoles); // Remove from current roles

				if (await _roleManager.RoleExistsAsync(model.Role))
				{
					await _userManager.AddToRoleAsync(user, model.Role); // Add new role if it exists
				}
				else
				{
					return BadRequest($"Role '{model.Role}' does not exist."); // Return error if role doesn't exist
				}
			}

			// Return success after the update
			return Ok($"User '{username}' updated successfully by admin.");
		}

		// Allows a user to update their profile
		[HttpPut("update-my-profile")]
		public async Task<IActionResult> UpdateMyProfile([FromBody] UserProfileUpdateDto model)
		{
			if (model.Username == null)
			{
				return BadRequest("No username");
			}
			var user = await _userManager.FindByNameAsync(model.Username); // Use the username from the model
			if (user == null)
				return NotFound("User not found."); // Return not found if user doesn't exist

			// Update user properties if provided, otherwise retain existing values
			user.Email = model.Email ?? user.Email;
			user.FirstName = model.FirstName ?? user.FirstName;
			user.LastName = model.LastName ?? user.LastName;

			var updateResult = await _userManager.UpdateAsync(user); // Attempt to update the user
			if (!updateResult.Succeeded)
				return BadRequest($"Error updating your profile: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}"); // Return any errors

			// Handle password update if provided
			if (!string.IsNullOrEmpty(model.Password))
			{
				var passwordRemovalResult = await _userManager.RemovePasswordAsync(user); // Remove current password
				if (!passwordRemovalResult.Succeeded)
					return BadRequest($"Error removing your password: {string.Join(", ", passwordRemovalResult.Errors.Select(e => e.Description))}"); // Return any errors

				var addPasswordResult = await _userManager.AddPasswordAsync(user, model.Password); // Add new password
				if (!addPasswordResult.Succeeded)
					return BadRequest($"Error setting your password: {string.Join(", ", addPasswordResult.Errors.Select(e => e.Description))}"); // Return any errors
			}

			// Return success after the profile is updated
			return Ok("Your profile has been updated successfully.");
		}

		// Change a user's role (accessible without Admin role but performs similar action)
		[HttpPut("public-like-admin/add-role")]
		public async Task<IActionResult> AddUserRole([FromBody] ChangeUserRoleRequestDto model)
		{
			// Validate input for username and role
			if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.RoleName))
				return BadRequest("Invalid input.");

			var user = await _userManager.FindByNameAsync(model.Username); // Find user by username
			if (user == null)
				return NotFound("User not found."); // Return not found if user doesn't exist

			var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
			if (!roleExists)
			{
				return BadRequest($"Role does not exist.");
			}

			var userRoleExists = await _userManager.IsInRoleAsync(user, model.RoleName);
			if (userRoleExists)
			{
				return BadRequest($"User already has the role.");
			}

			// Add the new role
			var result = await _userManager.AddToRoleAsync(user, model.RoleName);

			if (!result.Succeeded)
				return BadRequest("Failed to add role to user."); // Return error if role add fails

			// Return success after role add
			return Ok($"Role {model.RoleName} added to user successfully.");
		}

		// Change a user's role (accessible without Admin role but performs similar action)
		[HttpPut("public-like-admin/remove-role")]
		public async Task<IActionResult> RemoveUserRole([FromBody] ChangeUserRoleRequestDto model)
		{
			// Validate input for username and role
			if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.RoleName))
				return BadRequest("Invalid input.");

			var user = await _userManager.FindByNameAsync(model.Username); // Find user by username
			if (user == null)
				return NotFound("User not found."); // Return not found if user doesn't exist

			var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
			if (!roleExists)
			{
				return BadRequest($"Role does not exist.");
			}

			var userRoleExists = await _userManager.IsInRoleAsync(user, model.RoleName);
			if (!userRoleExists)
			{
				return BadRequest($"User does not have the role.");
			}

			// Add the new role
			var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

			if (!result.Succeeded)
				return BadRequest("Failed to remove user role."); // Return error if role remove fails

			// Return success after role remove
			return Ok($"User role removed to {model.RoleName} successfully.");
		}
	}
}