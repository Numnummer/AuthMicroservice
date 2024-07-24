using AuthMicroservice.Abstractions;
using AuthMicroservice.Services;

namespace AuthMicroservice
{
    public static class WebApplicationBuilderExtentions
    {
        public static void RegisterAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
        }
    }
}
