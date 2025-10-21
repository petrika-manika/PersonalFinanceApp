using FluentValidation;

namespace PersonalFinanceApp.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// Validator for GetCategoryByIdQuery using FluentValidation.
/// </summary>
public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}
