using MediatR;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Authentication.Common;
using PersonalFinanceApp.Domain.Entities;

namespace PersonalFinanceApp.Application.Features.Authentication.Commands.RegisterUser;

/// <summary>
/// Handler for RegisterUserCommand.
/// Creates a new user, hashes the password, saves to database, and generates JWT token.
/// </summary>
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthenticationResult>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;

    public RegisterUserCommandHandler(
        IApplicationDbContext context,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthenticationResult> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        // Hash the password using BCrypt
        var passwordHash = _passwordHasher.HashPassword(request.Password);

        // Create new User entity
        var user = new User(
            email: request.Email,
            passwordHash: passwordHash,
            firstName: request.FirstName,
            lastName: request.LastName
        );

        // Add user to database
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        // Generate JWT token
        var token = _jwtTokenService.GenerateToken(user.Id, user.Email);

        // Return result
        return new AuthenticationResult
        {
            UserId = user.Id,
            Token = token,
            Email = user.Email,
            FirstName = user.FirstName ?? string.Empty,
            LastName = user.LastName ?? string.Empty
        };
    }
}