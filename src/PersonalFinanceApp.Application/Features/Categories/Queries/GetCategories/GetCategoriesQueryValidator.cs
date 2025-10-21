using FluentValidation;

namespace PersonalFinanceApp.Application.Features.Categories.Queries.GetCategories;

/// <summary>
/// Validator for GetCategoriesQuery using FluentValidation.
/// </summary>
public class GetCategoriesQueryValidator : AbstractValidator<GetCategoriesQuery>
{
    public GetCategoriesQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}
