using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.Region.Countries
{
    public class TblCounties_TranslatesConfiguration : IEntityTypeConfiguration<TblCountries_Translates>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblCountries_Translates> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.CountryId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.TblCountrie)
                   .WithMany(a => a.tblCountries_Translates)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.TblLanguage)
                   .WithMany(a => a.tblCountries_Translates)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.LangId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
