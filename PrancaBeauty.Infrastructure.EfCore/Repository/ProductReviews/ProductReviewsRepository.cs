using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviews
{
    public class ProductReviewsRepository : BaseRepository<tblProductReviews>, IProductReviewsRepository
    {
        public ProductReviewsRepository(MainContext Context) : base(Context)
        {

        }
    }
}
