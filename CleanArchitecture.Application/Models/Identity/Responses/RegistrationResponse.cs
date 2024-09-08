namespace CleanArchitecture.Application.Models.Identity.Responses;

public class RegistrationResponse
{
    public string UserId { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}