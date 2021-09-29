using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Region.Language
{
    public class TblLanguageConfiguration : IEntityTypeConfiguration<TblLanguage>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblLanguage> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FlagImgId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Code).IsRequired().HasMaxLength(20);
            builder.Property(a => a.NativeName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Abbr).IsRequired().HasMaxLength(50);


            builder.HasOne(a => a.tblCountries)
                .WithMany(a => a.tblLanguages)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
