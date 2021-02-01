using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class TblRoleConfiguration : IEntityTypeConfiguration<TblRole>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblRole> builder)
        {

            builder.Property(a => a.ParentId).IsRequired(false).HasMaxLength(450);
            builder.Property(a => a.PageName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(500);
        }


    }
}
