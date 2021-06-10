using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.CountryAgg.Contracts;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Counties
{
    public class CountryRepository : BaseRepository<TblCountries>, ICountryRepository
    {
        public CountryRepository(MainContext context) : base(context)
        {

        }
    }
}
