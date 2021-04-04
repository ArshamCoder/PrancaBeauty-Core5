using Framework.Infrastructure;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataRole
    {
        readonly BaseRepository<TblRole> _repRoles;
        public AddDataRole()
        {
            _repRoles = new BaseRepository<TblRole>(new MainContext());
        }
        public void Run()
        {
            if (!_repRoles.Get.Any(a => a.Name == "FullControl"))
            {
                _repRoles.AddAsync(new TblRole()
                {
                    Id = new Guid().SequentialGuid(),
                    ParentId = null,
                    PageName = "FullControl",
                    Sort = 0,
                    Name = "FullControl",
                    NormalizedName = "FullControl".ToUpper(),
                    Description = "دسترسی مدیر کل"
                }, default, false).Wait();
            }

            _repRoles.SaveChangeAsync().Wait();
        }
    }
}
