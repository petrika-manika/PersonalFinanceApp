using MediatR;
using PersonalFinanceApp.Application.Features.Authentication.Common;

namespace PersonalFinanceApp.Application.Features.Authentication.Commands.RegisterUser;

/// <summary>
/// Command to register a new user in the system.
/// </summary>
public record RegisterUserCommand : IRequest<AuthenticationResult>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}