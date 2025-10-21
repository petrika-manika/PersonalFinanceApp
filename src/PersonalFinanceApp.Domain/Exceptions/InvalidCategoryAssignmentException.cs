using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Domain.Exceptions;

/// <summary>
/// Exception thrown when attempting to assign a category with mismatched type to a transaction.
/// </summary>
public class InvalidCategoryAssignmentException : DomainException
{
    public TransactionType TransactionType { get; }
    public CategoryType CategoryType { get; }

    public InvalidCategoryAssignmentException(TransactionType transactionType, CategoryType categoryType)
        : base($"Cannot assign a {categoryType} category to a {transactionType} transaction.")
    {
        TransactionType = transactionType;
        CategoryType = categoryType;
    }
}
