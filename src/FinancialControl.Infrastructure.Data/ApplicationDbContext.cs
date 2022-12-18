using FinancialControl.Core.Data;
using FinancialControl.Core.Entities;
using FinancialControl.Domain.Entities;
using FinancialControl.Infrastructure.Data.Utils.DateTimeConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinancialControl.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();
    
    public DbSet<Expense> Expenses => Set<Expense>();
    
    public DbSet<CreditCard> CreditCards => Set<CreditCard>();
    
    public DbSet<CreditCardExpense> CreditCardExpenses => Set<CreditCardExpense>();

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        
        configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");

        configurationBuilder.Properties<TimeOnly>().HaveConversion<TimeOnlyConverter>()
            .HaveColumnType("time");
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