using PersonalFinanceApp.Domain.Exceptions;

namespace PersonalFinanceApp.Domain.Entities;

public class User
{
    private readonly List<Transaction> _transactions = new();
    private readonly List<Category> _categories = new();

    public Guid Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // Navigation properties
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();

    // Private constructor for EF Core
    private User() { }

    public User(string email, string passwordHash, string? firstName = null, string? lastName = null)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidEmailException();
        
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new InvalidPasswordException();

        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidEmailException();

        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new InvalidPasswordException();

        PasswordHash = passwordHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string? firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        UpdatedAt = DateTime.UtcNow;
    }
}
