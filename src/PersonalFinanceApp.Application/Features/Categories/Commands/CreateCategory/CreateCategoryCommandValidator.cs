using FluentValidation;
using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.CreateCategory;

/// <summary>
/// Validator for CreateCategoryCommand using FluentValidation.
/// </summary>
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(x => x.Type)
            .NotNull().WithMessage("Category type is required.")
            .IsInEnum().WithMessage("Category type must be either Income or Expense.");
    }
}
