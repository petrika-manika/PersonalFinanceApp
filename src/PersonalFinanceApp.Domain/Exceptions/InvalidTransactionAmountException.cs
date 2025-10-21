namespace PersonalFinanceApp.Domain.Exceptions;

/// <summary>
/// Exception thrown when a transaction amount is invalid.
/// </summary>
public class InvalidTransactionAmountException : DomainException
{
    public decimal Amount { get; }

    public InvalidTransactionAmountException(decimal amount)
        : base($"Transaction amount must be greater than zero. Provided: {amount}")
    {
        Amount = amount;
    }
}
