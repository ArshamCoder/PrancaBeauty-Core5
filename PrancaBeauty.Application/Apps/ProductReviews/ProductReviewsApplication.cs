using PrancaBeauty.Domain.Product.ProductReviewsAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductReviews
{
    public class ProductReviewsApplication : IProductReviewsApplication
    {
        private readonly IProductReviewsRepository _ProductReviewsRepository;
        public ProductReviewsApplication(IProductReviewsRepository productReviewsRepository)
        {
            _ProductReviewsRepository = productReviewsRepository;
        }
    }
}
