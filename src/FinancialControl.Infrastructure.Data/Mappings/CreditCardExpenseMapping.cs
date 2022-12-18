using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infrastructure.Data.Mappings;

public class CreditCardExpenseMapping : BaseMapping<CreditCardExpense>, IEntityTypeConfiguration<CreditCardExpense>
{
    public override void Configure(EntityTypeBuilder<CreditCardExpense> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Value).HasPrecision(18, 2).IsRequired();
        
        //builder.HasOne(x => x.CreditCard).WithMany(x => x.Expenses).HasForeignKey(x => x.CreditCardId);

        builder.ToTable(nameof(CreditCardExpense));
    }
}