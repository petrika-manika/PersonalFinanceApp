namespace PersonalFinanceApp.Domain.Exceptions;

/// <summary>
/// Exception thrown when a password hash is missing or invalid.
/// </summary>
public class InvalidPasswordException : DomainException
{
    public InvalidPasswordException()
        : base("Password hash is required and cannot be empty.")
    {
    }
}
