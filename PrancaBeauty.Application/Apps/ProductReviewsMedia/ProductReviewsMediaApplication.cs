using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductReviewsMedia
{
    public class ProductReviewsMediaApplication : IProductReviewsMediaApplication
    {
        private readonly IProductReviewsMediaRepository _ProductReviewsMediaRepository;

        public ProductReviewsMediaApplication(IProductReviewsMediaRepository productReviewsMediaRepository)
        {
            _ProductReviewsMediaRepository = productReviewsMediaRepository;
        }
    }
}
