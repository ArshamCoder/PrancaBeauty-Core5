using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductVariantItems
{
    public class ProductVariantItemsRepository : BaseRepository<tblProductVariantItems>, IProductVariantItemsRepository
    {
        public ProductVariantItemsRepository(MainContext Context) : base(Context)
        {

        }
    }
}
