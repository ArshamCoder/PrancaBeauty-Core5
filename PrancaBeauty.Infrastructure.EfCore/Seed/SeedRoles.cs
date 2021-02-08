using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
using System;

namespace PrancaBeauty.Infrastructure.EfCore.Seed
{
    public class SeedRoles
    {
        public void Run(EntityTypeBuilder<TblRole> builder)
        {
            builder.HasData(new TblRole()
            {
                Id = new Guid().SequentialGuid(),
                ParentId = null,
                PageName = "FullControl",
                Sort = 0,
                Name = "FullControl",
                NormalizedName = "FullControl".ToUpper(),
                Description = "دسترسی مدیر کل"
            });
        }
    }
}
