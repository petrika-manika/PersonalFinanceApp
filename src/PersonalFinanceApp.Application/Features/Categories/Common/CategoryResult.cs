using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Application.Features.Categories.Common;

/// <summary>
/// Result returned after category operations (Create, Update).
/// </summary>
public record CategoryResult
{
    public Guid CategoryId { get; init; }
    public string Name { get; init; } = string.Empty;
    public CategoryType Type { get; init; }
    public DateTime CreatedAt { get; init; }
}
