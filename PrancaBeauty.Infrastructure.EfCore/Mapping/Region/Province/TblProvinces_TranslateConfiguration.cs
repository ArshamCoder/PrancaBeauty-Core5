using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.Region.Province
{
    public class TblProvinces_TranslateConfiguration : IEntityTypeConfiguration<TblProvinces_Translate>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblProvinces_Translate> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProvinceId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.TblProvinces)
                   .WithMany(a => a.tblProvinces_Translate)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.TblLanguage)
                   .WithMany(a => a.tblProvinces_Translate)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.LangId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
