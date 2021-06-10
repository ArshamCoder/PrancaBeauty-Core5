using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.ProvinceAgg.Contracts;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Province
{
    public class ProvinceRepository : BaseRepository<TblProvinces>, IProvinceRepository
    {
        public ProvinceRepository(MainContext context) : base(context)
        {

        }
    }
}
