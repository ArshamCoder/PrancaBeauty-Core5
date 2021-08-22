using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsAttribute
{
    public class ProductReviewsAttributeRepository : BaseRepository<tblProductReviewsAttribute>, IProductReviewsAttributeRepository
    {
        public ProductReviewsAttributeRepository(MainContext Context) : base(Context)
        {

        }
    }
}
