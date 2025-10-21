using MediatR;
using PersonalFinanceApp.Application.Features.Categories.Common;

namespace PersonalFinanceApp.Application.Features.Categories.Queries.GetCategories;

/// <summary>
/// Query to get all categories for a user.
/// </summary>
public record GetCategoriesQuery : IRequest<List<CategoryDto>>
{
    public Guid UserId { get; init; }
}
