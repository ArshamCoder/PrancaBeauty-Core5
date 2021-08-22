using Framework.Infrastructure;
using PrancaBeauty.Domain.Keywords.KeywordAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Keywords
{
    public class KeywordRepository : BaseRepository<tblProducts>, IKeywordRepository
    {
        public KeywordRepository(MainContext Context) : base(Context)
        {

        }
    }
}
