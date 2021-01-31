using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
using PrancaBeauty.Infrastructure.EfCore.Contracts;
using System;

namespace PrancaBeauty.Infrastructure.EfCore.Context
{
    public class MainContext : IdentityDbContext<TblUser, TblRole, Guid>
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        public MainContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region رجیستر خودکار هر کلاسی که IEntityConf دارد

            var entitiesAssembly = typeof(IEntityConf).Assembly;
            builder.RegisterEntityTypeConfiguration(entitiesAssembly);


            #endregion

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
