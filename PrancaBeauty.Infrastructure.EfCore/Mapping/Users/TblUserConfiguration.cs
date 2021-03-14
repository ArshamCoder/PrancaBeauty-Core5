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

            builder.Property(a => a.PasswordPhoneNumber)
                .IsRequired(false)
                .HasMaxLength(5000);


            //fluent api join
            // join between user and accessLevel
            //جوین همیشه از سمت جدولی که چند است میخورد
            // هر دسترسی میتواند برای چندتا کاربر باشد
            //پس جدول کاربران چند به حساب می آید
            builder.HasOne(x => x.TblAccessLevels)
                .WithMany(x => x.TblUsers)
                .HasPrincipalKey(x => x.Id) //معرفی کلید خارجی
                .HasForeignKey(x => x.AccessLevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
