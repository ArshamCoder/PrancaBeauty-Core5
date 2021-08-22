using PrancaBeauty.Domain.Product.ProductVariantAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductVariants
{
    public class ProductVariantsApplication : IProductVariantsApplication
    {
        private readonly IProductVariantsRepository _ProductVariantsRepository;

        public ProductVariantsApplication(IProductVariantsRepository productVariantsRepository)
        {
            _ProductVariantsRepository = productVariantsRepository;
        }
    }
}
