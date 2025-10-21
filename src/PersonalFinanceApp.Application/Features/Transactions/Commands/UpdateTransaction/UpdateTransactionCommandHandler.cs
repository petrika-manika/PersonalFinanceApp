using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Transactions.Common;
using PersonalFinanceApp.Domain.Entities;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.UpdateTransaction;

/// <summary>
/// Handler for UpdateTransactionCommand.
/// Updates an existing transaction and verifies ownership.
/// </summary>
public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, TransactionResult>
{
    private readonly IApplicationDbContext _context;

    public UpdateTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionResult> Handle(
        UpdateTransactionCommand request,
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
            throw new UnauthorizedAccessException("You don't have permission to update this transaction.");
        }

        // Get category if CategoryId is provided
        Category? category = null;
        if (request.CategoryId.HasValue)
        {
            category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId.Value, cancellationToken);
        }

        // Update transaction
        transaction.UpdateAmount(request.Amount);
        transaction.UpdateType(request.Type);
        transaction.UpdateCategory(category);
        transaction.UpdateDescription(request.Description);
        transaction.UpdateDate(request.Date);

        // Save changes
        await _context.SaveChangesAsync(cancellationToken);

        // Return result
        return new TransactionResult
        {
            TransactionId = transaction.Id,
            Amount = transaction.Amount,
            Type = transaction.Type,
            CategoryId = transaction.CategoryId,
            CategoryName = category?.Name,
            Description = transaction.Description,
            Date = transaction.Date,
            CreatedAt = transaction.CreatedAt
        };
    }
}
