using Framework.Infrastructure;
using PrancaBeauty.Domain.Keywords.Keywords_Products.Contracts;
using PrancaBeauty.Domain.Keywords.Keywords_Products.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Keywords_Products
{
    public class Keywords_ProductsRepository : BaseRepository<tblKeywords_Products>, IKeywords_ProductsRepository
    {
        public Keywords_ProductsRepository(MainContext Context) : base(Context)
        {

        }
    }
}
