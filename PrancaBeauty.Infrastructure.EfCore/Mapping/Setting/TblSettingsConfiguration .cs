using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Setting.SettingAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Setting
{
    public class TblSettingsConfiguration : IEntityTypeConfiguration<TblSetting>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblSetting> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.SiteTitle).IsRequired().HasMaxLength(100);
            builder.Property(a => a.SiteDescription).IsRequired().HasMaxLength(300);
            builder.Property(a => a.SiteEmail).IsRequired().HasMaxLength(100);
            builder.Property(a => a.SitePhoneNumber).IsRequired().HasMaxLength(50);

            builder.HasOne(a => a.TblLanguage)
                .WithMany(a => a.TblSettings)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.LangId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
