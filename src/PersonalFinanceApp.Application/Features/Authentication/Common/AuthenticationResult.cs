namespace PersonalFinanceApp.Application.Features.Authentication.Common;

/// <summary>
/// Result returned after successful authentication (login or registration).
/// Contains the user information and JWT authentication token.
/// </summary>
public record AuthenticationResult
{
    public Guid UserId { get; init; }
    public string Token { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}