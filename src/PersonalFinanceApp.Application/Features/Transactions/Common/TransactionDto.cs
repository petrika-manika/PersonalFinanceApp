using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Transactions.Common;

/// <summary>
/// DTO for reading transaction details.
/// </summary>
public record TransactionDto
{
    public Guid Id { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public Guid? CategoryId { get; init; }
    public string? CategoryName { get; init; }
    public string? Description { get; init; }
    public DateTime Date { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
