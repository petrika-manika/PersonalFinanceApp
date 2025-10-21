using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Transactions.Common;

namespace PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactionById;

/// <summary>
/// Handler for GetTransactionByIdQuery.
/// Retrieves a specific transaction and verifies ownership.
/// </summary>
public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDto>
{
    private readonly IApplicationDbContext _context;

    public GetTransactionByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionDto> Handle(
        GetTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Find transaction by Id with Category included (single query)
        var transaction = await _context.Transactions
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (transaction == null)
        {
            throw new KeyNotFoundException($"Transaction with ID {request.Id} not found.");
        }

        // Verify ownership
        if (transaction.UserId != request.UserId)
        {
            throw new UnauthorizedAccessException("You don't have permission to view this transaction.");
        }

        // Map to DTO
        return new TransactionDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            Type = transaction.Type,
            CategoryId = transaction.CategoryId,
            CategoryName = transaction.Category != null ? transaction.Category.Name : null,
            Description = transaction.Description,
            Date = transaction.Date,
            CreatedAt = transaction.CreatedAt,
            UpdatedAt = transaction.UpdatedAt
        };
        
    }
}
