using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductReviewsAttributeValues
{
    public class tblProductReviewsAttributeValuesConfiguration : IEntityTypeConfiguration<tblProductReviewsAttributeValues>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductReviewsAttributeValues> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductReviewId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductReviewAttributeId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Value).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.tblProductReviews)
                   .WithMany(a => a.tblProductReviewsAttributeValues)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductReviewId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblProductReviewsAttribute)
                   .WithMany(a => a.tblProductReviewsAttributeValues)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductReviewAttributeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
