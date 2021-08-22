using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductTopic
{
    public class tblProductTopicConfiguration : IEntityTypeConfiguration<tblProductTopic>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductTopic> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FileId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(150);

            builder.HasOne(a => a.tblFiles)
                   .WithMany(a => a.tblProductTopic)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.FileId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
