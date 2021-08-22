using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductSellerAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductSellerAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductSellers
{
    public class ProductSellersRepsoitory : BaseRepository<tblProductSellers>, IProductSellersRepsoitory
    {
        public ProductSellersRepsoitory(MainContext Context) : base(Context)
        {

        }
    }
}
