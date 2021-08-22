using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductReviewsLikes
{
    public class tblProductReviewsLikesConfiguration : IEntityTypeConfiguration<tblProductReviewsLikes>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductReviewsLikes> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductReviewId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.UserId).IsRequired().HasMaxLength(450);

            builder.HasOne(a => a.tblProductReviews)
                   .WithMany(a => a.tblProductReviewsLikes)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductReviewId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblUsers)
                   .WithMany(a => a.tblProductReviewsLikes)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
