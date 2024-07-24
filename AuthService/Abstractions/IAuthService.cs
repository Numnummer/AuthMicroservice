using AuthMicroservice.Models.Auth;
using AuthMicroservice.Models.Auth.SecondFactor;

namespace AuthMicroservice.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResult?> RegistrateUser(RegistrationUserData registrationUserData);
        Task SendEmailCodeAsync(string email);
        Task<AuthResult?> SecondFactorSignInAsync(SecondFactorPost data);
        Task<bool> DeleteUserAsync(string email);
        Task<AuthResult?> SignInUserAsync(SignInUserData signInUserData);
    }
}
