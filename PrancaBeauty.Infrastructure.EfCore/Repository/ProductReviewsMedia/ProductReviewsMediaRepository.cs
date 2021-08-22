using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsMedia
{
    public class ProductReviewsMediaRepository : BaseRepository<tblProductReviewsMedia>, IProductReviewsMediaRepository
    {
        public ProductReviewsMediaRepository(MainContext Context) : base(Context)
        {

        }
    }
}
