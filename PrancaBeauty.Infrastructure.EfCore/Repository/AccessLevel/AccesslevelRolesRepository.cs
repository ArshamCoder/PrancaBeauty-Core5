using Framework.Infrastructure;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel
{
    public class AccesslevelRolesRepository : BaseRepository<TblAccessLevel_Role>, IAccesslevelRolesRepository
    {
        public AccesslevelRolesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
