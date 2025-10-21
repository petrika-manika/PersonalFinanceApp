using PersonalFinanceApp.Domain.Enums;
using PersonalFinanceApp.Domain.Exceptions;

namespace PersonalFinanceApp.Domain.Entities;

public class Category
{
    private readonly List<Transaction> _transactions = new();

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public CategoryType Type { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Navigation properties
    public User User { get; private set; } = null!;
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    // Private constructor for EF Core
    private Category() { }

    public Category(Guid userId, string name, CategoryType type)
    {
        if (userId == Guid.Empty)
            throw new InvalidUserIdException();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidCategoryNameException();

        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Type = type;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidCategoryNameException();

        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateType(CategoryType type)
    {
        Type = type;
        UpdatedAt = DateTime.UtcNow;
    }
}
