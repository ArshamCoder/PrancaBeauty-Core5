using PrancaBeauty.Domain.Product.ProductPricesAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductPrices
{
    public class ProductPriceApplication : IProductPriceApplication
    {
        private readonly IProductPricesRepository _ProductPricesRepository;

        public ProductPriceApplication(IProductPricesRepository productPricesRepository)
        {
            _ProductPricesRepository = productPricesRepository;
        }
    }
}
