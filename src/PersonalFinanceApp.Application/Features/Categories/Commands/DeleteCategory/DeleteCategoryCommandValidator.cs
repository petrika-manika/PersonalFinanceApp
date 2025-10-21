using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.DeleteCategory;

/// <summary>
/// Validator for DeleteCategoryCommand using FluentValidation.
/// </summary>
public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x)
            .MustAsync(CategoryExistsAndBelongsToUser)
            .WithMessage("Category not found or you don't have permission to delete it.");
    }

    private async Task<bool> CategoryExistsAndBelongsToUser(
        DeleteCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return await _context.Categories
            .AnyAsync(c => c.Id == command.Id && c.UserId == command.UserId, cancellationToken);
    }
}
