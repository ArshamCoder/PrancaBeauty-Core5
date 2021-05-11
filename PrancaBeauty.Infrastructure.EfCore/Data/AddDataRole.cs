using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
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
                else
                {
                    id = _repRoles.Get.Where(a => a.Name == "CanManageAccessLevel").Select(a => a.Id).Single();
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


            #region ManageUsersPage
            {
                Guid _Id = new Guid().SequentialGuid();
                if (!_repRoles.Get.Any(a => a.Name == "CanManageUsers"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = _Id,
                        ParentId = null,
                        PageName = "ManageUsersPage",
                        Sort = 60,
                        Name = "CanManageUsers",
                        NormalizedName = "CanManageUsers".ToUpper(),
                        Description = "توانایی مدیریت کاربران"
                    }, default, false).Wait();
                }
                else
                {
                    _Id = _repRoles.Get.Where(a => a.Name == "CanManageUsers").Select(a => a.Id).Single();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanViewListUsers"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = _Id,
                        PageName = "ManageUsersPage",
                        Sort = 60,
                        Name = "CanViewListUsers",
                        NormalizedName = "CanViewListUsers".ToUpper(),
                        Description = "توانایی مشاهده لیست کاربران"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanAddUsers"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = _Id,
                        PageName = "ManageUsersPage",
                        Sort = 70,
                        Name = "CanAddUsers",
                        NormalizedName = "CanAddUsers".ToUpper(),
                        Description = "توانایی افزودن کاربر جدید"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanEditUsers"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = _Id,
                        PageName = "ManageUsersPage",
                        Sort = 80,
                        Name = "CanEditUsers",
                        NormalizedName = "CanEditUsers".ToUpper(),
                        Description = "توانایی ویرایش کاربر"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanRemoveUsers"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = _Id,
                        PageName = "ManageUsersPage",
                        Sort = 90,
                        Name = "CanRemoveUsers",
                        NormalizedName = "CanRemoveUsers".ToUpper(),
                        Description = "توانایی حذف سطح دسترسی"
                    }, default, false).Wait();
                }
                if (!_repRoles.Get.Any(a => a.Name == "CanChangeUsersStatus"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = _Id,
                        PageName = "ManageUsersPage",
                        Sort = 100,
                        Name = "CanChangeUsersStatus",
                        NormalizedName = "CanChangeUsersStatus".ToUpper(),
                        Description = "توانایی تغییر وضعیت کاربر"
                    }, default, false).Wait();
                }

                if (!_repRoles.Get.Any(a => a.Name == "CanChangeUsersAccessLevel"))
                {
                    _repRoles.AddAsync(new TblRole()
                    {
                        Id = new Guid().SequentialGuid(),
                        ParentId = _Id,
                        PageName = "ManageUsersPage",
                        Sort = 110,
                        Name = "CanChangeUsersAccessLevel",
                        NormalizedName = "CanChangeUsersAccessLevel".ToUpper(),
                        Description = "توانایی تغییر سطح دسترسی کاربر"
                    }, default, false).Wait();
                }
            }
            #endregion














            _repRoles.SaveChangeAsync().Wait();
        }
    }
}
