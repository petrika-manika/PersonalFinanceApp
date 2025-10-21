using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Application.Features.Transactions.Commands.CreateTransaction;
using PersonalFinanceApp.Application.Features.Transactions.Commands.DeleteTransaction;
using PersonalFinanceApp.Application.Features.Transactions.Commands.UpdateTransaction;
using PersonalFinanceApp.Application.Features.Transactions.Common;
using PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactionById;
using PersonalFinanceApp.Application.Features.Transactions.Queries.GetTransactions;

namespace PersonalFinanceApp.API.Controllers;

/// <summary>
/// Controller for transaction management operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize] // Require authentication for all endpoints
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets the authenticated user's ID from the JWT token claims.
    /// </summary>
    private Guid GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            throw new UnauthorizedAccessException("User ID not found in token.");
        }
        return userId;
    }

    /// <summary>
    /// Creates a new transaction for the authenticated user.
    /// </summary>
    /// <param name="command">The create transaction command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created transaction.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(TransactionResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TransactionResult>> Create(
        [FromBody] CreateTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var commandWithUserId = command with { UserId = userId };
        
        var result = await _mediator.Send(commandWithUserId, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.TransactionId }, result);
    }

    /// <summary>
    /// Gets transactions for the authenticated user with optional filters.
    /// </summary>
    /// <param name="month">Optional: Filter by month (1-12).</param>
    /// <param name="year">Optional: Filter by year.</param>
    /// <param name="categoryId">Optional: Filter by category ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of transactions.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<TransactionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<TransactionDto>>> GetAll(
        [FromQuery] int? month,
        [FromQuery] int? year,
        [FromQuery] Guid? categoryId,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var query = new GetTransactionsQuery 
        { 
            UserId = userId,
            Month = month,
            Year = year,
            CategoryId = categoryId
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Gets a specific transaction by ID.
    /// </summary>
    /// <param name="id">The transaction ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The transaction details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TransactionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var query = new GetTransactionByIdQuery { Id = id, UserId = userId };
        
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Updates an existing transaction.
    /// </summary>
    /// <param name="id">The transaction ID.</param>
    /// <param name="command">The update transaction command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated transaction.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TransactionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TransactionResult>> Update(
        Guid id,
        [FromBody] UpdateTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var commandWithIds = command with { Id = id, UserId = userId };
        
        var result = await _mediator.Send(commandWithIds, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a transaction.
    /// </summary>
    /// <param name="id">The transaction ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Success status.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var command = new DeleteTransactionCommand { Id = id, UserId = userId };
        
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
