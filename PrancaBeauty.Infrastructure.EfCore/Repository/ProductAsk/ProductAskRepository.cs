using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductAskAgg.Contarcts;
using PrancaBeauty.Domain.Product.ProductAskAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductAsk
{
    public class ProductAskRepository : BaseRepository<tblProductAsk>, IProductAskRepository
    {
        public ProductAskRepository(MainContext Context) : base(Context)
        {

        }
    }
}
