using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.AddressAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class TblAddressConfiguration : IEntityTypeConfiguration<TblAddress>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblAddress> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.UserId).IsRequired().HasMaxLength(450);
            builder.Property(a => a.CountryId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProviceId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.CityId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.District).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Plaque).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Unit).IsRequired(false).HasMaxLength(100);
            builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(100);
            builder.Property(a => a.NationalCode).IsRequired().HasMaxLength(100);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.PhoneNumber).IsRequired().HasMaxLength(100);

            builder.HasOne(a => a.TblUser)
                .WithMany(a => a.TblAddress)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.TblCountries)
                .WithMany(a => a.tblAddress)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
