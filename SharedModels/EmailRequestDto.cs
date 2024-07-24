namespace SharedModels
{
    public record EmailRequestDto(string from,
        string to,
        string subject,
        string body);

}
