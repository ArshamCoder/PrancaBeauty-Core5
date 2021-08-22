using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductReviewsAttributeValues
{
    public class ProductReviewsAttributeValuesApplication : IProductReviewsAttributeValuesApplication
    {
        private readonly IProductReviewsAttributeValuesRepository _ProductReviewsAttributeValuesRepository;

        public ProductReviewsAttributeValuesApplication(IProductReviewsAttributeValuesRepository productReviewsAttributeValuesRepository)
        {
            _ProductReviewsAttributeValuesRepository = productReviewsAttributeValuesRepository;
        }
    }
}
