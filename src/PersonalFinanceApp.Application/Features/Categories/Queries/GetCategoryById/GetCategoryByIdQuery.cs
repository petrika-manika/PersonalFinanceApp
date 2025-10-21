using MediatR;
using PersonalFinanceApp.Application.Features.Categories.Common;

namespace PersonalFinanceApp.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// Query to get a specific category by ID.
/// </summary>
public record GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
}
