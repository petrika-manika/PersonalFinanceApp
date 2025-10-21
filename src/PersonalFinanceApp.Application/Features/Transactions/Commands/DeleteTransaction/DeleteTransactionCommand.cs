using MediatR;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.DeleteTransaction;

/// <summary>
/// Command to delete a transaction.
/// </summary>
public record DeleteTransactionCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
}
