using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductVariants
{
    public class tblProductVariants_TranslatesConfiguration : IEntityTypeConfiguration<tblProductVariants_Translates>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductVariants_Translates> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductVariantId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.tblProductVariants)
                   .WithMany(a => a.tblProductVariants_Translates)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblLanguages)
                   .WithMany(a => a.tblProductVariants_Translates)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.LangId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
