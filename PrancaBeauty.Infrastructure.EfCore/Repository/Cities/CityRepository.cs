using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.CityAgg.Contracts;
using PrancaBeauty.Domain.Region.CityAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Cities
{
    public class CityRepository : BaseRepository<TblCities>, ICityRepository
    {
        public CityRepository(MainContext context) : base(context)
        {

        }
    }
}
