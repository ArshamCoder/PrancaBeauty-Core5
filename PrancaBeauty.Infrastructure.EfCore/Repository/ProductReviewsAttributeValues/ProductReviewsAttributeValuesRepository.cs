using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsAttributeValues
{
    public class ProductReviewsAttributeValuesRepository : BaseRepository<tblProductReviewsAttributeValues>, IProductReviewsAttributeValuesRepository
    {
        public ProductReviewsAttributeValuesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
