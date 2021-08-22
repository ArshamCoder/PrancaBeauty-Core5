using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductVariants
{
    public class ProductVariants_TranslatesRepository : BaseRepository<tblProductVariants_Translates>, IProductVariants_TranslatesRepository
    {
        public ProductVariants_TranslatesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
