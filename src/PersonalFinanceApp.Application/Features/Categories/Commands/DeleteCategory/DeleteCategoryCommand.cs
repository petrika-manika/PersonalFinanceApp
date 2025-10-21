using MediatR;

namespace PersonalFinanceApp.Application.Features.Categories.Commands.DeleteCategory;

/// <summary>
/// Command to delete a category.
/// </summary>
public record DeleteCategoryCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
}
