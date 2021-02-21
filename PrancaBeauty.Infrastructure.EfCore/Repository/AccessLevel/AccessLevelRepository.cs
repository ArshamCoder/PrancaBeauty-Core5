using Framework.Infrastructure;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel
{
    public class AccessLevelRepository : BaseRepository<TblAccessLevels>, IAccessLevelRepository
    {
        public AccessLevelRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
