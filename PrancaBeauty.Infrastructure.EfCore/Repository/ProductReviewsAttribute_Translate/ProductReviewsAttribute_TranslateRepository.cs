using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsAttribute_Translate
{
    public class ProductReviewsAttribute_TranslateRepository : BaseRepository<tblProductReviewsAttribute>, IProductReviewsAttribute_TranslateRepository
    {
        public ProductReviewsAttribute_TranslateRepository(MainContext Context) : base(Context)
        {

        }
    }
}
