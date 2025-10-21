using MediatR;
using PersonalFinanceApp.Application.Features.Transactions.Common;

namespace PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactions;

/// <summary>
/// Query to get transactions for a user with optional filters.
/// </summary>
public record GetTransactionsQuery : IRequest<List<TransactionDto>>
{
    public Guid UserId { get; init; }
    public int? Month { get; init; }
    public int? Year { get; init; }
    public Guid? CategoryId { get; init; }
}
