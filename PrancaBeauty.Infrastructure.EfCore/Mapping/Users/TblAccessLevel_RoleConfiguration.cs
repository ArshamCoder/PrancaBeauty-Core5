using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class TblAccessLevel_RoleConfiguration : IEntityTypeConfiguration<TblAccessLevel_Role>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblAccessLevel_Role> builder)
        {
            builder.HasKey(a => a.Id); // مشخص کردن کلید اصلی جدول
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.AccessLevelId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.RoleId).IsRequired().HasMaxLength(450);

            builder.HasOne(x => x.TblAccessLevels)
                .WithMany(x => x.TblAccessLevel_Roles)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.AccessLevelId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.TblRole)
                .WithMany(x => x.TblAccessLevel_Roles)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
