using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductMediaAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductMedia
{
    public class tblProductMediaConfiguration : IEntityTypeConfiguration<tblProductMedia>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductMedia> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FileId).IsRequired().HasMaxLength(150);

            builder.HasOne(a => a.tblProducts)
                   .WithMany(a => a.tblProductMedia)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblFiles)
                   .WithOne(a => a.tblProductMedia)
                   .HasPrincipalKey<TblFile>(a => a.Id)
                   .HasForeignKey<tblProductMedia>(a => a.FileId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
