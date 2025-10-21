using PersonalFinanceApp.Domain.Enums;
using PersonalFinanceApp.Domain.Exceptions;

namespace PersonalFinanceApp.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid? CategoryId { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public string? Description { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Navigation properties
    public User User { get; private set; } = null!;
    public Category? Category { get; private set; }

    // Private constructor for EF Core
    private Transaction() { }

    public Transaction(
        Guid userId,
        decimal amount,
        TransactionType type,
        DateTime date,
        string? description = null,
        Category? category = null)
    {
        if (userId == Guid.Empty)
            throw new InvalidUserIdException();

        if (amount <= 0)
            throw new InvalidTransactionAmountException(amount);

        if (category != null)
        {
            ValidateCategoryTypeMatch(type, category.Type);
        }

        Id = Guid.NewGuid();
        UserId = userId;
        CategoryId = category?.Id;
        Amount = amount;
        Type = type;
        Description = description;
        Date = date;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateAmount(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionAmountException(amount);

        Amount = amount;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCategory(Category? category)
    {
        if (category != null)
        {
            ValidateCategoryTypeMatch(Type, category.Type);
            CategoryId = category.Id;
        }
        else
        {
            CategoryId = null;
        }

        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDate(DateTime date)
    {
        Date = date;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateType(TransactionType type)
    {
        if (Category != null)
        {
            ValidateCategoryTypeMatch(type, Category.Type);
        }

        Type = type;
        UpdatedAt = DateTime.UtcNow;
    }

    private void ValidateCategoryTypeMatch(TransactionType transactionType, CategoryType categoryType)
    {
        if ((transactionType == TransactionType.Income && categoryType != CategoryType.Income) ||
            (transactionType == TransactionType.Expense && categoryType != CategoryType.Expense))
        {
            throw new InvalidCategoryAssignmentException(transactionType, categoryType);
        }
    }
}
