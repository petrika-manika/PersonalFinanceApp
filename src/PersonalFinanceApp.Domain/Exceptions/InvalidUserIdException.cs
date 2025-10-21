namespace PersonalFinanceApp.Domain.Exceptions;

/// <summary>
/// Exception thrown when a user ID is invalid or empty.
/// </summary>
public class InvalidUserIdException : DomainException
{
    public InvalidUserIdException()
        : base("User ID is required and cannot be empty.")
    {
    }
}
