using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Transactions.Common;
using PersonalFinanceApp.Domain.Entities;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.CreateTransaction;

/// <summary>
/// Handler for CreateTransactionCommand.
/// Creates a new transaction and saves it to the database.
/// </summary>
public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionResult>
{
    private readonly IApplicationDbContext _context;

    public CreateTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionResult> Handle(
        CreateTransactionCommand request,
        CancellationToken cancellationToken)
    {
        // Get category if CategoryId is provided
        Category? category = null;
        if (request.CategoryId.HasValue)
        {
            category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId.Value, cancellationToken);
        }

        // Create new Transaction entity
        var transaction = new Transaction(
            userId: request.UserId,
            amount: request.Amount,
            type: request.Type,
            date: request.Date,
            description: request.Description,
            category: category
        );

        // Add transaction to database
        _context.Transactions.Add(transaction);
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
