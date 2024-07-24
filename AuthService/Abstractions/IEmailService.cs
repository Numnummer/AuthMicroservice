namespace AuthMicroservice.Abstractions
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email, string body, string subject);
    }
}
