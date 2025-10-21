using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Transactions.Common;

namespace PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactions;

/// <summary>
/// Handler for GetTransactionsQuery.
/// Retrieves transactions for a specific user with optional filters.
/// </summary>
public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, List<TransactionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTransactionsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionDto>> Handle(
        GetTransactionsQuery request,
        CancellationToken cancellationToken)
    {
        // Start with base query
        var query = _context.Transactions
            .Include(t => t.Category)
            .Where(t => t.UserId == request.UserId);

        // Apply filters if provided
        if (request.Month.HasValue)
        {
            query = query.Where(t => t.Date.Month == request.Month.Value);
        }

        if (request.Year.HasValue)
        {
            query = query.Where(t => t.Date.Year == request.Year.Value);
        }

        if (request.CategoryId.HasValue)
        {
            query = query.Where(t => t.CategoryId == request.CategoryId.Value);
        }

        // Execute query and map to DTO
        var transactions = await query
            .OrderByDescending(t => t.Date)
            .Select(t => new TransactionDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Type = t.Type,
                CategoryId = t.CategoryId,
                CategoryName = t.Category != null ? t.Category.Name : null,
                Description = t.Description,
                Date = t.Date,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            })
            .ToListAsync(cancellationToken);

        return transactions;
    }
}
