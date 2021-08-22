using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductVariants
{
    public class tblProductVariantsConfiguration : IEntityTypeConfiguration<tblProductVariants>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductVariants> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.VariantType).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);

        }
    }
}
