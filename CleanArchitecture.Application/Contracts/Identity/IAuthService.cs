using CleanArchitecture.Application.Models.Identity.Requests;
using CleanArchitecture.Application.Models.Identity.Responses;

namespace CleanArchitecture.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}