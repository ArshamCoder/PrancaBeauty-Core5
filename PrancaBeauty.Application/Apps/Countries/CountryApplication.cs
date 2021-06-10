using PrancaBeauty.Domain.Region.CountryAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Countries
{
    public class CountryApplication : ICountryApplication
    {
        private readonly ICountryRepository _CountryRepository;

        public CountryApplication(ICountryRepository countryRepository)
        {
            _CountryRepository = countryRepository;
        }
    }
}
