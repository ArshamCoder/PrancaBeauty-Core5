using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Users
{
    public class TblUserConfiguration : IEntityTypeConfiguration<TblUser>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblUser> builder)
        {
            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
