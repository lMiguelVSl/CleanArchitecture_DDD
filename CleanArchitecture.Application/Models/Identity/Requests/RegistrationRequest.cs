using CleanArchitecture.Application.Models.Identity.Shared;

namespace CleanArchitecture.Application.Models.Identity.Requests;

public class RegistrationRequest: RegistrationUser
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}