using Framework.Domain;
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

            #region DbSet Automatic

            var entitiesAssembly = typeof(IEntity).Assembly;
            builder.RegisterAllEntities<IEntity>(entitiesAssembly);

            #endregion



            #region رجیستر خودکار هر کلاسی که IEntityConf دارد
            var entitiesConfAssembly = typeof(IEntityConf).Assembly;
            builder.RegisterEntityTypeConfiguration(entitiesConfAssembly);


            #endregion

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;");
        }
    }
}
