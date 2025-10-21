using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceApp.Domain.Entities;
using PersonalFinanceApp.Domain.Enums;

namespace PersonalFinanceApp.Infrastructure.Data.Configurations;

/// <summary>
/// Entity configuration for Transaction entity using Fluent API.
/// </summary>
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        // Table name
        builder.ToTable("Transactions");

        // Primary key
        builder.HasKey(t => t.Id);

        // Properties
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedNever(); // Guid generated in domain

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.CategoryId)
            .IsRequired(false); // Nullable foreign key

        builder.Property(t => t.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)") // Precision for currency
            .HasPrecision(18, 2);

        builder.Property(t => t.Type)
            .IsRequired()
            .HasConversion<string>() // Store enum as string
            .HasMaxLength(50);

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.Date)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.Property(t => t.UpdatedAt)
            .IsRequired();

        // Indexes
        builder.HasIndex(t => t.UserId)
            .HasDatabaseName("IX_Transactions_UserId");

        builder.HasIndex(t => t.CategoryId)
            .HasDatabaseName("IX_Transactions_CategoryId");

        builder.HasIndex(t => t.Date)
            .HasDatabaseName("IX_Transactions_Date");

        builder.HasIndex(t => new { t.UserId, t.Date })
            .HasDatabaseName("IX_Transactions_UserId_Date");

        // Relationships
        builder.HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(t => t.Category)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict) // Changed from SetNull to Restrict to avoid cascade path conflict
            .IsRequired(false);
    }
}
