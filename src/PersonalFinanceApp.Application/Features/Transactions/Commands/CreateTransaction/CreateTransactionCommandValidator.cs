using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.CreateTransaction;

/// <summary>
/// Validator for CreateTransactionCommand using FluentValidation.
/// </summary>
public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateTransactionCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(x => x.Type)
            .NotNull().WithMessage("Transaction type is required.")
            .IsInEnum().WithMessage("Transaction type must be either Income or Expense.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.");

        RuleFor(x => x)
            .MustAsync(CategoryMustExistAndBelongToUser)
            .When(x => x.CategoryId.HasValue)
            .WithMessage("Category not found or you don't have permission to use it.");
    }

    private async Task<bool> CategoryMustExistAndBelongToUser(
        CreateTransactionCommand command,
        CancellationToken cancellationToken)
    {
        if (!command.CategoryId.HasValue)
            return true;

        return await _context.Categories
            .AnyAsync(c => c.Id == command.CategoryId.Value && c.UserId == command.UserId, cancellationToken);
    }
}
