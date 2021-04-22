using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataAccessLevel
    {
        private readonly BaseRepository<TblAccessLevels> _repAccessLevel;
        private BaseRepository<TblRole> _repRoles;

        public AddDataAccessLevel()
        {
            _repAccessLevel = new BaseRepository<TblAccessLevels>(new MainContext());
            _repRoles = new BaseRepository<TblRole>(new MainContext());
        }


        public void Run()
        {
            if (!_repAccessLevel.Get.Any(a => a.Name == "GeneralManager"))
            {
                var qAccRole = new TblAccessLevels()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "GeneralManager",
                    TblAccessLevel_Roles = new List<TblAccessLevel_Role>()
                };

                foreach (var item in _repRoles.Get.ToList())
                {
                    qAccRole.TblAccessLevel_Roles.Add(new TblAccessLevel_Role()
                    {
                        Id = new Guid().SequentialGuid(),
                        AccessLevelId = qAccRole.Id,
                        RoleId = item.Id
                    });
                }

                _repAccessLevel.AddAsync(qAccRole, default, false).Wait();
            }
            if (!_repAccessLevel.Get.Any(a => a.Name == "Users"))
            {
                _repAccessLevel.AddAsync(new TblAccessLevels()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "Users"
                }, default, false).Wait();
            }


            _repAccessLevel.SaveChangeAsync().Wait();
        }
    }

}
