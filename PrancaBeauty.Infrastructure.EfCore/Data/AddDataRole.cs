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
            if (!_repRoles.Get.Any(a => a.Name == "AdminPage"))
            {
                _repRoles.AddAsync(new TblRole()
                {
                    Id = new Guid().SequentialGuid(),
                    ParentId = null,
                    PageName = "AdminPage",
                    Sort = 0,
                    Name = "AdminPage",
                    NormalizedName = "AdminPage".ToUpper(),
                    Description = "دسترسی به پنل مدیریت"
                }, default, false).Wait();
            }


            #region ManageAccessLevelPage
            {
                Guid id = new Guid().SequentialGuid();
                if (!_repRoles.Get.Any(a => a.Name == "CanManageAccessLevel"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = id,
                        ParentId = null,
                        PageName = "ManageAccessLevelPage",
                        Sort = 10,
                        Name = "CanManageAccessLevel",
                        NormalizedName = "CanManageAccessLevel".ToUpper(),
                        Description = "توانایی مدیریت سطوح دسترسی"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanViewListAccessLevel"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = id,
                        PageName = "ManageAccessLevelPage",
                        Sort = 20,
                        Name = "CanViewListAccessLevel",
                        NormalizedName = "CanViewListAccessLevel".ToUpper(),
                        Description = "توانایی مشاهده لیست سطوح دسترسی"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanAddAccessLevel"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = id,
                        PageName = "ManageAccessLevelPage",
                        Sort = 30,
                        Name = "CanAddAccessLevel",
                        NormalizedName = "CanAddAccessLevel".ToUpper(),
                        Description = "توانایی افزودن سطح دسترسی"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanEditAccessLevel"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = id,
                        PageName = "ManageAccessLevelPage",
                        Sort = 40,
                        Name = "CanEditAccessLevel",
                        NormalizedName = "CanEditAccessLevel".ToUpper(),
                        Description = "توانایی ویرایش سطح دسترسی"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanRemoveAccessLevel"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = id,
                        PageName = "ManageAccessLevelPage",
                        Sort = 50,
                        Name = "CanRemoveAccessLevel",
                        NormalizedName = "CanRemoveAccessLevel".ToUpper(),
                        Description = "توانایی حذف سطح دسترسی"
                    }, default, false).Wait();
                }
            }
            #endregion

            _repRoles.SaveChangeAsync().Wait();
        }
    }
}
