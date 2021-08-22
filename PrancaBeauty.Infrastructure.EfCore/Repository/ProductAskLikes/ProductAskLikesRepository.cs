using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductAskLikesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductAskLikesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductAskLikes
{
    public class ProductAskLikesRepository : BaseRepository<tblProductAskLikes>, IProductAskLikesRepository
    {
        public ProductAskLikesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
