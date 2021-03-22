using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.LanguageAgg.Contracts;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Region
{
    public class LanguageRepository : BaseRepository<TblLanguage>, ILanguageRepository
    {
        public LanguageRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
