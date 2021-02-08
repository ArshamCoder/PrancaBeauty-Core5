using Framework.Infrastructure;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataAccessLevel
    {
        private BaseRepository<TblAccessLevels> _repAccessLevel;

        public AddDataAccessLevel()
        {
            _repAccessLevel = new BaseRepository<TblAccessLevels>(new MainContext());
        }


        public void Run()
        {
            if (!_repAccessLevel.Get.Any(a => a.Name == "GeneralManager"))
            {
                _repAccessLevel.AddAsync(new TblAccessLevels()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "GeneralManager"
                }, default, false).Wait();
            }



            _repAccessLevel.SaveChangeAsync().Wait();
        }
    }

}
}
