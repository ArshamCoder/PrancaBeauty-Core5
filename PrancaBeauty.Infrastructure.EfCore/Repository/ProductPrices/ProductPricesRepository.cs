using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductPricesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPricesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductPrices
{
    public class ProductPricesRepository : BaseRepository<tblProductPrices>, IProductPricesRepository
    {
        public ProductPricesRepository(MainContext context) : base(context)
        {

        }
    }
}
