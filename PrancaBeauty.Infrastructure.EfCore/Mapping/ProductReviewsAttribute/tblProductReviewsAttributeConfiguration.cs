using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductReviewsAttribute
{
    public class tblProductReviewsAttributeConfiguration : IEntityTypeConfiguration<tblProductReviewsAttribute>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductReviewsAttribute> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.TopicId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.tblProductTopic)
                   .WithMany(a => a.tblProductReviewsAttribute)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.TopicId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
