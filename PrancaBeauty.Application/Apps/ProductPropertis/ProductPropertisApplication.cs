using PrancaBeauty.Domain.Product.ProductPropertisAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductPropertis
{
    public class ProductPropertisApplication : IProductPropertisApplication
    {
        private readonly IProductPropertisRepository _ProductPropertisRepository;

        public ProductPropertisApplication(IProductPropertisRepository productPropertisRepository)
        {
            _ProductPropertisRepository = productPropertisRepository;
        }
    }
}
