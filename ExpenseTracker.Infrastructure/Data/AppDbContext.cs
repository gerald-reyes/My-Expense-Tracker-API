using System;
using System.Collections.Generic;
using ExpenseTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=expensesControl;User Id=sa;Password=SqlServer1995;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExpenseC__3214EC07053432A1");

            entity.ToTable("ExpenseCategory");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            // Index name to match your script
            entity.HasIndex(x => x.ParentId)
                .HasDatabaseName("IX_Category_ParentId");

            // Self-referencing FK (NO ACTION/RESTRICT to mirror the SQL)
            entity.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
