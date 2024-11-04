using SoftwareManagementAPI.Dtos.Auth.Request;
using SoftwareManagementAPI.Dtos.Auth.Response;
using SoftwareManagementAPI.Models;

namespace SoftwareManagementAPI.Services
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(ApplicationUserModel user);

        Task<RefreshTokenResponseDto> VerifyToken(TokenRequestDto tokenRequest);
    }
}