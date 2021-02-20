using Framework.Infrastructure;
using PrancaBeauty.Domain.SettingAgg.Contracts;
using PrancaBeauty.Domain.SettingAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Setting
{
    public class SettingRepository : BaseRepository<TblSetting>, ISettingRepository
    {
        public SettingRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
