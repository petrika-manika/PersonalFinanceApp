namespace PersonalFinanceApp.Domain.Exceptions;

/// <summary>
/// Exception thrown when a category name is missing or invalid.
/// </summary>
public class InvalidCategoryNameException : DomainException
{
    public InvalidCategoryNameException()
        : base("Category name is required and cannot be empty.")
    {
    }
}
