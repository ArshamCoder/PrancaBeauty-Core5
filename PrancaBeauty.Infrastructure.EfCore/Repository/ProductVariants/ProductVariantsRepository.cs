using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductVariants
{
    public class ProductVariantsRepository : BaseRepository<tblProductVariants>, IProductVariantsRepository
    {
        public ProductVariantsRepository(MainContext Context) : base(Context)
        {

        }
    }
}
