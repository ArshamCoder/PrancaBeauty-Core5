using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductVariantItems
{
    public class ProductVariantItemsApplication : IProductVariantItemsApplication
    {
        private readonly IProductVariantItemsRepository _ProductVariantItemsRepository;

        public ProductVariantItemsApplication(IProductVariantItemsRepository productVariantItemsRepository)
        {
            _ProductVariantItemsRepository = productVariantItemsRepository;
        }
    }
}
