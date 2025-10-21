using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Categories.Common;

namespace PersonalFinanceApp.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// Handler for GetCategoryByIdQuery.
/// Retrieves a specific category and verifies ownership.
/// </summary>
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(
        GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Find category by Id
        var category = await _context.Categories
            .Where(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (category == null)
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");

        // Verify ownership
        if (category.UserId != request.UserId)
            throw new UnauthorizedAccessException("You don't have permission to view this category.");

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Type = category.Type,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };
    }
}
