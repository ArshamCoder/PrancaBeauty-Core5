using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class TblAccessLevelConfiguration : IEntityTypeConfiguration<TblAccessLevels>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblAccessLevels> builder)
        {
            builder.HasKey(a => a.Id); // مشخص کردن کلید اصلی جدول
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        }
    }
}
