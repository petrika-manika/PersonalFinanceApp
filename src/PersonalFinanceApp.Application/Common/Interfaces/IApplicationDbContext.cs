using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Domain.Entities;

namespace PersonalFinanceApp.Application.Common.Interfaces;

/// <summary>
/// Application database context interface for dependency inversion.
/// </summary>
public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<Category> Categories { get; }

    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
