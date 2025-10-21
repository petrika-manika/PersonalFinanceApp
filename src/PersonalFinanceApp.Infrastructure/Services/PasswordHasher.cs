using PersonalFinanceApp.Application.Common.Interfaces;

namespace PersonalFinanceApp.Infrastructure.Services;

/// <summary>
/// Password hashing service using BCrypt.
/// </summary>
public class PasswordHasher : IPasswordHasher
{
    /// <summary>
    /// Hashes a password using BCrypt with automatic salt generation.
    /// </summary>
    /// <param name="password">The plain text password to hash.</param>
    /// <returns>The BCrypt hashed password.</returns>
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Verifies that a plain text password matches a BCrypt hash.
    /// </summary>
    /// <param name="password">The plain text password to verify.</param>
    /// <param name="hash">The BCrypt hash to verify against.</param>
    /// <returns>True if the password matches; otherwise, false.</returns>
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
