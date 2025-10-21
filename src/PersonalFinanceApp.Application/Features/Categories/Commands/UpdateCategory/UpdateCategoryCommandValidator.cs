using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.UpdateCategory;

/// <summary>
/// Validator for UpdateCategoryCommand using FluentValidation.
/// </summary>
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(x => x.Type)
            .NotNull().WithMessage("Category type is required.")
            .IsInEnum().WithMessage("Category type must be either Income or Expense.");

        RuleFor(x => x)
            .MustAsync(CategoryExistsAndBelongsToUser)
            .WithMessage("Category not found or you don't have permission to update it.");
    }

    private async Task<bool> CategoryExistsAndBelongsToUser(
        UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return await _context.Categories
            .AnyAsync(c => c.Id == command.Id && c.UserId == command.UserId, cancellationToken);
    }
}
