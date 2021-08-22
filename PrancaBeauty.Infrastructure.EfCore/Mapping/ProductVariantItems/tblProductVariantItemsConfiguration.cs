using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductVariantItems
{
    public class tblProductVariantItemsConfiguration : IEntityTypeConfiguration<tblProductVariantItems>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductVariantItems> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductSellerId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductVariantId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Value).IsRequired().HasMaxLength(500);

            builder.HasOne(a => a.tblProducts)
                   .WithMany(a => a.tblProductVariantItems)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblProductSellers)
                   .WithMany(a => a.tblProductVariantItems)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductSellerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.tblProductVariants)
                   .WithMany(a => a.tblProductVariantItems)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductVariantId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
