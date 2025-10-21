using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Transactions.Common;

/// <summary>
/// Result returned after transaction operations (Create, Update).
/// </summary>
public record TransactionResult
{
    public Guid TransactionId { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public Guid? CategoryId { get; init; }
    public string? CategoryName { get; init; }
    public string? Description { get; init; }
    public DateTime Date { get; init; }
    public DateTime CreatedAt { get; init; }
}
