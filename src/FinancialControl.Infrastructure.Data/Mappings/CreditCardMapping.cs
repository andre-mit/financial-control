using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infrastructure.Data.Mappings;

public class CreditCardMapping : BaseMapping<CreditCard>, IEntityTypeConfiguration<CreditCard> 
{
    public override void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        base.Configure(builder);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        
        //builder.HasMany(x => x.Expenses).WithOne(x => x.CreditCard).HasForeignKey(x => x.CreditCardId);

        builder.ToTable(nameof(CreditCard));
    }
}