using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.SellerAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.Sellers
{
    public class tblSellersConfiguration : IEntityTypeConfiguration<tblSellers>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblSellers> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.UserId).IsRequired().HasMaxLength(450);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.tblUsers)
                .WithOne(a => a.tblSellers)
                .HasPrincipalKey<TblUser>(a => a.Id)
                .HasForeignKey<tblSellers>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
