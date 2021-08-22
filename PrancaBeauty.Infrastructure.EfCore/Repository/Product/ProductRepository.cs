using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Product
{
    public class ProductRepository : BaseRepository<tblProducts>, IProductRepository
    {
        public ProductRepository(MainContext Context) : base(Context)
        {

        }
    }
}
