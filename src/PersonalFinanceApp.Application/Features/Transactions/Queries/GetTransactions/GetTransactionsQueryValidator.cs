using FluentValidation;

namespace PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactions;

/// <summary>
/// Validator for GetTransactionsQuery using FluentValidation.
/// </summary>
public class GetTransactionsQueryValidator : AbstractValidator<GetTransactionsQuery>
{
    public GetTransactionsQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12)
            .When(x => x.Month.HasValue)
            .WithMessage("Month must be between 1 and 12.");

        RuleFor(x => x.Year)
            .GreaterThan(1900)
            .When(x => x.Year.HasValue)
            .WithMessage("Year must be greater than 1900.");
    }
}
