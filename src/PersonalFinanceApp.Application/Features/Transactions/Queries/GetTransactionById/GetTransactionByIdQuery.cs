using MediatR;
using PersonalFinanceApp.Application.Features.Transactions.Common;

namespace PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactionById;

/// <summary>
/// Query to get a specific transaction by ID.
/// </summary>
public record GetTransactionByIdQuery : IRequest<TransactionDto>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
}
