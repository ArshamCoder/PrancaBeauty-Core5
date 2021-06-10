using PrancaBeauty.Domain.Region.ProvinceAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Province
{
    public class ProvinceApplication : IProvinceApplication
    {
        private readonly IProvinceRepository _ProvinceRepository;
        public ProvinceApplication(IProvinceRepository provinceRepository)
        {
            _ProvinceRepository = provinceRepository;
        }
    }
}
