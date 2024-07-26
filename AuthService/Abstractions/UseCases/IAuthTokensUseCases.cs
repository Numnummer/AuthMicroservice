using AuthMicroservice.Models;
using AuthMicroservice.Models.Auth;
using AuthMicroservice.Models.Auth.RequestModels;
using Microsoft.AspNetCore.Identity;


namespace AuthMicroservice.Abstractions.UseCases
{
    public interface IAuthTokensUseCases
    {
        Task<AuthResult> GenerateJwtAndRefreshTokensAsync(AppUser user);
        Task<AuthResult?> RefreshJwtTokenAsync(TokenRequest request);
    }
}
