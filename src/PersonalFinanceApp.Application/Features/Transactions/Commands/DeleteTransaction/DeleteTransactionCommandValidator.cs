using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Application.Common.Interfaces;

namespace PersonalFinanceApp.Application.Features.Transactions.Commands.DeleteTransaction;

/// <summary>
/// Validator for DeleteTransactionCommand using FluentValidation.
/// </summary>
public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTransactionCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Transaction ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(x => x)
            .MustAsync(TransactionExistsAndBelongsToUser)
            .WithMessage("Transaction not found or you don't have permission to delete it.");
    }

    private async Task<bool> TransactionExistsAndBelongsToUser(
        DeleteTransactionCommand command,
        CancellationToken cancellationToken)
    {
        return await _context.Transactions
            .AnyAsync(t => t.Id == command.Id && t.UserId == command.UserId, cancellationToken);
    }
}
