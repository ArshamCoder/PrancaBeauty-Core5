using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductReviewsMedia
{
    public class tblProductReviewsMediaConfiguration : IEntityTypeConfiguration<tblProductReviewsMedia>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductReviewsMedia> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductReviewsId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FileId).IsRequired().HasMaxLength(150);

            builder.HasOne(a => a.tblProductReviews)
                   .WithMany(a => a.tblProductReviewsMedia)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductReviewsId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblFiles)
                   .WithOne(a => a.tblProductReviewsMedia)
                   .HasPrincipalKey<TblFile>(a => a.Id)
                   .HasForeignKey<tblProductReviewsMedia>(a => a.FileId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
