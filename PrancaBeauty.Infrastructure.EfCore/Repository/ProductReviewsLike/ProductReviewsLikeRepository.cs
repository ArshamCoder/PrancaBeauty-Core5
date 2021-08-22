using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsLike
{
    public class ProductReviewsLikeRepository : BaseRepository<tblProductReviewsLikes>, IProductReviewsLikeRepository
    {
        public ProductReviewsLikeRepository(MainContext Context) : base(Context)
        {

        }
    }
}
