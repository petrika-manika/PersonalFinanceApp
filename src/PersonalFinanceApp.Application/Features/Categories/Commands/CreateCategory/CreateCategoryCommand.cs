using MediatR;
using PersonalFinanceApp.Application.Features.Categories.Common;
using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.CreateCategory;

/// <summary>
/// Command to create a new category.
/// </summary>
public record CreateCategoryCommand : IRequest<CategoryResult>
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = string.Empty;
    public CategoryType Type { get; init; }
}
