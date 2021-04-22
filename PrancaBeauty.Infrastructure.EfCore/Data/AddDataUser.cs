using Framework.Common.ExMethod;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataUser
    {

        private readonly BaseRepository<TblUser> _repUser;
        private readonly BaseRepository<TblAccessLevels> _repAccessLevel;
        private BaseRepository<TblRole> _repRoles;
        MainContext _Context;
        public AddDataUser()
        {
            _repUser = new BaseRepository<TblUser>(new MainContext());
            _repAccessLevel = new BaseRepository<TblAccessLevels>(new MainContext());
            _repRoles = new BaseRepository<TblRole>(new MainContext());
            _Context = new MainContext();
        }
        public void Run()
        {
            if (!_repUser.Get.Any(a => a.UserName == "arshambh7@gmail.com"))
            {
                Guid UserId = new Guid().SequentialGuid();
                _repUser.AddAsync(new TblUser()
                {
                    Id = UserId,
                    AccessLevelId = _repAccessLevel.Get.Where(a => a.Name == "GeneralManager").Select(a => a.Id).Single(),
                    FirstName = "آرشام",
                    LastName = "بهبهانی",
                    IsActive = true,
                    Date = DateTime.Now,
                    UserName = "arshambh7@gmail.com",
                    NormalizedUserName = "ArshamCoder".ToUpper(),
                    Email = "arshambh7@gmail.com",
                    NormalizedEmail = "arshambh7@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEO4DDm//CF91OA/DWo5+TkznvEzE0UshISWpEGkOTKNCHtV2fXosKhfN3Mw3TSegAA==",
                    SecurityStamp = "QHZXXDN4PZUNNXGC6LQRVNOZ5EGGIKWH",
                    ConcurrencyStamp = "37116a3b-0da5-460e-b266-d5243f62e5c8",
                    PhoneNumber = "9010112829",
                    PhoneNumberConfirmed = true,
                }, default, true).Wait();


                foreach (var item in _repRoles.Get.ToList())
                {
                    _Context.Add(new IdentityUserRole<Guid>
                    {
                        UserId = UserId,
                        RoleId = item.Id
                    });
                }

                _Context.SaveChanges();
            }
        }
    }
}
