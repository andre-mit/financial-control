using FinancialControl.Core.Data;
using FinancialControl.Core.Entities;
using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Expense> Expenses { get; set; }
    
    public DbSet<CreditCard> CreditCards { get; set; }
    
    public DbSet<CreditCardExpense> CreditCardExpenses { get; set; }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nameof(Entity.CreatedAt)) != null || entry.Entity.GetType().GetProperty(nameof(Entity.UpdatedAt)) != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(Entity.CreatedAt)).CurrentValue = DateTime.Now;
            }
            else
            {
                entry.Property(nameof(Entity.CreatedAt)).IsModified = false;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(nameof(Entity.UpdatedAt)).CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    public bool Commit()
    {
        return SaveChanges() > 0;
    }

    public async Task<bool> CommitAsync()
    {
        return await SaveChangesAsync() > 0;
    }

    public void Rollback()
    {
        
    }
}