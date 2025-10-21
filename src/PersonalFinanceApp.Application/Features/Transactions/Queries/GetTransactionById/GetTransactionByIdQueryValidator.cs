using FluentValidation;

namespace PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactionById;

/// <summary>
/// Validator for GetTransactionByIdQuery using FluentValidation.
/// </summary>
public class GetTransactionByIdQueryValidator : AbstractValidator<GetTransactionByIdQuery>
{
    public GetTransactionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Transaction ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}
