namespace PersonalFinanceApp.Domain.Exceptions;

/// <summary>
/// Exception thrown when a required email is missing or invalid.
/// </summary>
public class InvalidEmailException : DomainException
{
    public InvalidEmailException()
        : base("Email is required and cannot be empty.")
    {
    }

    public InvalidEmailException(string message)
        : base(message)
    {
    }
}
