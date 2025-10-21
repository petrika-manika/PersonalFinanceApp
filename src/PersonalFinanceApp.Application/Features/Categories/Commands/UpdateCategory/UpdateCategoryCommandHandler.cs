using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Categories.Common;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.UpdateCategory;

/// <summary>
/// Handler for UpdateCategoryCommand.
/// Updates an existing category and verifies ownership.
/// </summary>
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResult>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryResult> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Find category by Id
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
        }

        // Verify it belongs to the user
        if (category.UserId != request.UserId)
        {
            throw new UnauthorizedAccessException("You don't have permission to update this category.");
        }

        // Update category
        category.UpdateName(request.Name);
        category.UpdateType(request.Type);

        // Save changes
        await _context.SaveChangesAsync(cancellationToken);

        // Return result
        return new CategoryResult
        {
            CategoryId = category.Id,
            Name = category.Name,
            Type = category.Type,
            CreatedAt = category.CreatedAt
        };
    }
}
