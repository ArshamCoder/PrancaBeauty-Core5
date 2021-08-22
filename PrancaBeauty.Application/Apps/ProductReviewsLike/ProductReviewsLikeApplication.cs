using PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductReviewsLike
{
    public class ProductReviewsLikeApplication : IProductReviewsLikeApplication
    {
        private readonly IProductReviewsLikeRepository _ProductReviewsLikeRepository;

        public ProductReviewsLikeApplication(IProductReviewsLikeRepository productReviewsLikeRepository)
        {
            _ProductReviewsLikeRepository = productReviewsLikeRepository;
        }
    }
}
