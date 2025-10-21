using MediatR;
using PersonalFinanceApp.Application.Features.Authentication.Common;

namespace PersonalFinanceApp.Application.Features.Authentication.Commands.LoginUser;

/// <summary>
/// Command to authenticate a user and generate a JWT token.
/// </summary>
public record LoginUserCommand : IRequest<AuthenticationResult>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}