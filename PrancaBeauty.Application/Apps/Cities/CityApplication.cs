using PrancaBeauty.Domain.Region.CityAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Cities
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository _CityRepository;

        public CityApplication(ICityRepository cityRepository)
        {
            _CityRepository = cityRepository;
        }
    }
}
