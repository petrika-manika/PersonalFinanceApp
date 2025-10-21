using MediatR;
using PersonalFinanceApp.Application.Features.Transactions.Common;
using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.UpdateTransaction;

/// <summary>
/// Command to update an existing transaction.
/// </summary>
public record UpdateTransactionCommand : IRequest<TransactionResult>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public Guid? CategoryId { get; init; }
    public string? Description { get; init; }
    public DateTime Date { get; init; }
}
