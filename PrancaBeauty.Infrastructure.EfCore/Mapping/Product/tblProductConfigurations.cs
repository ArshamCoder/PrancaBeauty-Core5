using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.Product
{
    public class tblProductConfigurations : IEntityTypeConfiguration<tblProducts>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProducts> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.AuthorUserId).IsRequired().HasMaxLength(450);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Descreption).IsRequired();


            builder.HasOne(a => a.tblAuthorUser)
                   .WithMany(a => a.tblProducts)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.AuthorUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.tblCategory)
                   .WithMany(a => a.tblProducts)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
