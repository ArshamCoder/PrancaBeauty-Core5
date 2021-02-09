using Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
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
            if (!_repUser.Get.Any(a => a.UserName == "RezaAhmadi"))
            {
                Guid UserId = new Guid().SequentialGuid();
                _repUser.AddAsync(new TblUser()
                {
                    Id = UserId,
                    AccessLevelId = _repAccessLevel.Get.Where(a => a.Name == "GeneralManager").Select(a => a.Id).Single(),
                    FirstName = "محمدرضا",
                    LastName = "احمدی",
                    IsActive = true,
                    Date = DateTime.Now,
                    UserName = "RezaAhmadi",
                    NormalizedUserName = "RezaAhmadi".ToUpper(),
                    Email = "reza9025@gmail.com",
                    NormalizedEmail = "reza9025@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAELVlHmEilr3l0mizs5GxKWdCQIL8ys6zuHdVro+hNsU7RxYC9HtJqdajundVGRFC5Q==",
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
