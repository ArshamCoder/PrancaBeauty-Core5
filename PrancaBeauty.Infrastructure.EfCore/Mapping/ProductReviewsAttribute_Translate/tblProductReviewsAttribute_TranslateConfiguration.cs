using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductReviewsAttribute_Translate
{
    public class tblProductReviewsAttribute_TranslateConfiguration : IEntityTypeConfiguration<tblProductReviewsAttribute_Translate>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductReviewsAttribute_Translate> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductReviewsAttributeId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(150);

            builder.HasOne(a => a.tblLanguages)
                   .WithMany(a => a.tblProductReviewsAttribute_Translate)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.LangId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.tblProductReviewsAttribute)
                   .WithMany(a => a.tblProductReviewsAttribute_Translate)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductReviewsAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
