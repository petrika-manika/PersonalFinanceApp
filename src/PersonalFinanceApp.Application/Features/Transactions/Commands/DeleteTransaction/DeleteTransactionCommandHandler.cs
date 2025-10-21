using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.DeleteTransaction;

/// <summary>
/// Handler for DeleteTransactionCommand.
/// Deletes a transaction and verifies ownership.
/// </summary>
public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        DeleteTransactionCommand request,
        CancellationToken cancellationToken)
    {
        // Find transaction by Id
        var transaction = await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (transaction == null)
        {
            throw new KeyNotFoundException($"Transaction with ID {request.Id} not found.");
        }

        // Verify it belongs to the user
        if (transaction.UserId != request.UserId)
        {
            throw new UnauthorizedAccessException("You don't have permission to delete this transaction.");
        }

        // Delete transaction
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
