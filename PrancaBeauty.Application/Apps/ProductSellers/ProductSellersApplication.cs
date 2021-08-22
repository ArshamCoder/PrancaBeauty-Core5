using PrancaBeauty.Domain.Product.ProductSellerAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductSellers
{
    public class ProductSellersApplication : IProductSellersApplication
    {
        private readonly IProductSellersRepsoitory _ProductSellersRepsoitory;

        public ProductSellersApplication(IProductSellersRepsoitory productSellersRepsoitory)
        {
            _ProductSellersRepsoitory = productSellersRepsoitory;
        }
    }
}
