using AuthMicroservice.Models;
using AuthMicroservice.Models.Auth;
using AuthMicroservice.Models.Auth.RequestModels;
using Microsoft.AspNetCore.Identity;


namespace AuthMicroservice.Abstractions
{
    public interface ITokenService
    {
        Task<AuthResult> GenerateJwtTokenAsync(AppUser user);
        Task<AuthResult> RefreshTokenAsync(TokenRequest request);
    }
}
