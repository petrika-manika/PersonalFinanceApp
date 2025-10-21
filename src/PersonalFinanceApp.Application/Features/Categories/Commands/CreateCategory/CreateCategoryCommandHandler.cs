using MediatR;
using PersonalFinanceApp.Application.Common.Interfaces;
using PersonalFinanceApp.Application.Features.Categories.Common;
using PersonalFinanceApp.Domain.Entities;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.CreateCategory;

/// <summary>
/// Handler for CreateCategoryCommand.
/// Creates a new category and saves it to the database.
/// </summary>
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResult>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryResult> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Create new Category entity
        var category = new Category(
            userId: request.UserId,
            name: request.Name,
            type: request.Type
        );

        // Add category to database
        _context.Categories.Add(category);
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
