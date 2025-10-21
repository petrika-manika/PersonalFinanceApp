using MediatR;
using PersonalFinanceApp.Application.Features.Transactions.Common;
using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.CreateTransaction;

/// <summary>
/// Command to create a new transaction.
/// </summary>
public record CreateTransactionCommand : IRequest<TransactionResult>
{
    public Guid UserId { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public Guid? CategoryId { get; init; }
    public string? Description { get; init; }
    public DateTime Date { get; init; }
}
