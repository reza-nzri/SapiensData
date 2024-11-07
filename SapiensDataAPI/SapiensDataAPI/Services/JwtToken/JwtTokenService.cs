// SapiensDataAPI/Services/JwtTokenService.cs
using Microsoft.AspNetCore.Identity; // Import Identity for managing user roles and identity
using Microsoft.IdentityModel.Tokens; // Import for security token handling
using SapiensDataAPI.Dtos.Auth.Request; // Import request DTOs for authentication
using SapiensDataAPI.Dtos.Auth.Response; // Import response DTOs for authentication
using SapiensDataAPI.Models; // Import user model
using System.IdentityModel.Tokens.Jwt; // Import for handling JWT tokens
using System.Security.Claims; // Import for handling claims in JWT
using System.Text;
using System.Text.Json; // Import for encoding the JWT key

namespace SapiensDataAPI.Services.JwtToken // Define the service namespace
{
	public class JwtTokenService : IJwtTokenService // Implement the IJwtTokenService interface
	{
		private readonly UserManager<ApplicationUserModel> _userManager; // User manager for managing user data and roles
		private readonly IConfiguration _configuration; // Configuration to access settings like JWT key, issuer, etc.

		public JwtTokenService(UserManager<ApplicationUserModel> userManager, IConfiguration configuration) // Constructor with DI for UserManager and Configuration
		{
			_userManager = userManager; // Initialize the user manager
			_configuration = configuration; // Initialize the configuration
		}

		public async Task<string> GenerateToken(ApplicationUserModel user) // Method to generate a JWT token
		{
			// Get user roles
			var roles = await _userManager.GetRolesAsync(user);

			// Create claims list
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Add user's username as a claim
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Add a unique token ID
            };

			// Add roles as claims
			claims.AddRange(roles.Select(role => new Claim("role", role))); // Add each user role as a claim

			// Create the key from configuration
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // Generate the symmetric security key
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Create signing credentials using HMAC SHA256

			// Create the token
			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"], // Define the token issuer
				audience: _configuration["Jwt:Audience"], // Define the token audience
				claims: claims, // Pass the claims into the token
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])), // Set token expiration time
				signingCredentials: creds); // Pass signing credentials

			// Return the generated token
			return new JwtSecurityTokenHandler().WriteToken(token); // Write the token and return it as a string
		}

		public async Task<RefreshTokenResponseDto> VerifyToken(TokenRequestDto tokenRequest) // Method to verify a token
		{
			var tokenHandler = new JwtSecurityTokenHandler(); // Instantiate a token handler
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true, // Validate the signing key of the token
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), // Set the signing key from configuration
				ValidateIssuer = true,
				ValidIssuer = _configuration["Jwt:Issuer"],
				ValidateAudience = true,
				ValidAudience = _configuration["Jwt:Audience"],
				ClockSkew = TimeSpan.Zero // Avoid clock skew issues
			};

			try
			{
				//var principal = tokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out var validatedToken); // Validate the token
				var (principal, validatedToken) = await Task.Run(() =>
				{
					// Validate the token and capture principal and validatedToken
					var principal = tokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out var validatedToken);
					return (principal, validatedToken);
				});

				// Check if the token is expired
				if (validatedToken.ValidTo < DateTime.UtcNow) // Check if the token expiration time has passed
				{
					return new RefreshTokenResponseDto
					{
						IsValid = false, // Set token as invalid
						ErrorMessage = "Token is expired." // Return token expiration error message
					};
				}

				return new RefreshTokenResponseDto
				{
					IsValid = true, // Set token as valid
					Claims = principal.Claims.Select(c => new ClaimDto { Type = c.Type, Value = c.Value }).ToList() // Map claims to a list of ClaimDto
				};
			}
			catch (Exception ex) // Catch any exceptions during token validation
			{
				return new RefreshTokenResponseDto
				{
					IsValid = false, // Set token as invalid in case of an error
					ErrorMessage = ex.Message // Return the error message
				};
			}
		}

		public JsonDocument DecodeJwtPayloadToJson(string token)
		{
			// Check if token is empty or null
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentException("JWT token cannot be null or empty.");
			}

			// Split the token into parts
			var parts = token.Split('.');
			if (parts.Length < 3)
			{
				throw new ArgumentException("Invalid JWT token format.");
			}

			// Decode the payload (second part) from Base64
			var payload = parts[1];
			var base64Payload = payload.Replace('-', '+').Replace('_', '/'); // Standard Base64 format
			var padding = 4 - base64Payload.Length % 4;
			if (padding < 4)
			{
				base64Payload += new string('=', padding);
			}

			var bytes = Convert.FromBase64String(base64Payload);

			// Parse and return the decoded JSON
			return JsonDocument.Parse(bytes);
		}

	}
}