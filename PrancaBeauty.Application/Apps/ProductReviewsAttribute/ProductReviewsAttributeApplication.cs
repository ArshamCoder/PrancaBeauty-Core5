using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductReviewsAttribute
{
    public class ProductReviewsAttributeApplication : IProductReviewsAttributeApplication
    {
        private readonly IProductReviewsAttributeRepository _ProductReviewsAttributeRepository;

        public ProductReviewsAttributeApplication(IProductReviewsAttributeRepository productReviewsAttributeRepository)
        {
            _ProductReviewsAttributeRepository = productReviewsAttributeRepository;
        }
    }
}
