using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Categories.Common;

/// <summary>
/// DTO for reading category details.
/// </summary>
public record CategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public CategoryType Type { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
