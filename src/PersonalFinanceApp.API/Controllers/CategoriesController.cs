using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Application.Features.Categories.Commands.CreateCategory;
using PersonalFinanceApp.Application.Features.Categories.Commands.DeleteCategory;
using PersonalFinanceApp.Application.Features.Categories.Commands.UpdateCategory;
using PersonalFinanceApp.Application.Features.Categories.Common;
using PersonalFinanceApp.Application.Features.Categories.Queries.GetCategories;
using PersonalFinanceApp.Application.Features.Categories.Queries.GetCategoryById;

namespace PersonalFinanceApp.API.Controllers;

/// <summary>
/// Controller for category management operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize] // Require authentication for all endpoints
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
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
    /// Creates a new category for the authenticated user.
    /// </summary>
    /// <param name="command">The create category command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created category.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryResult>> Create(
        [FromBody] CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var commandWithUserId = command with { UserId = userId };
        
        var result = await _mediator.Send(commandWithUserId, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.CategoryId }, result);
    }

    /// <summary>
    /// Gets all categories for the authenticated user.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of categories.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<CategoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<CategoryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var query = new GetCategoriesQuery { UserId = userId };
        
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Gets a specific category by ID.
    /// </summary>
    /// <param name="id">The category ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The category details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var query = new GetCategoryByIdQuery { Id = id, UserId = userId };
        
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The category ID.</param>
    /// <param name="command">The update category command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated category.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CategoryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryResult>> Update(
        Guid id,
        [FromBody] UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var commandWithIds = command with { Id = id, UserId = userId };
        
        var result = await _mediator.Send(commandWithIds, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">The category ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Success status.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var command = new DeleteCategoryCommand { Id = id, UserId = userId };
        
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
