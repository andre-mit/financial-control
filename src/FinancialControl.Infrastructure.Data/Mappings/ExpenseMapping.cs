using FinancialControl.Domain.Entities;
using FinancialControl.Infrastructure.Data.Utils.DateTimeConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infrastructure.Data.Mappings;

public class ExpenseMapping : BaseMapping<Expense>, IEntityTypeConfiguration<Expense>
{
    public override void Configure(EntityTypeBuilder<Expense> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Value).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.DueDate).HasConversion(typeof(DateOnlyConverter));

        builder.ToTable(nameof(Expense));
    }
}