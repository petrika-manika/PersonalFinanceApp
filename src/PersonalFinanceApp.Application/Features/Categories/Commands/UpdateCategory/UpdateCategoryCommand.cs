using MediatR;
using PersonalFinanceApp.Application.Features.Categories.Common;
using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.UpdateCategory;

/// <summary>
/// Command to update an existing category.
/// </summary>
public record UpdateCategoryCommand : IRequest<CategoryResult>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Name { get; init; } = string.Empty;
    public CategoryType Type { get; init; }
}
