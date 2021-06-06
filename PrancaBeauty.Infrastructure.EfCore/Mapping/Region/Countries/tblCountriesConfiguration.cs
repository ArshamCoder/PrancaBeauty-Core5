using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.Region.Countries
{
    public class TblCountriesConfiguration : IEntityTypeConfiguration<TblCountries>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblCountries> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FlagImgId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(150);

            builder.HasOne(a => a.tblFiles)
                   .WithMany(a => a.TblCountries)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.FlagImgId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
