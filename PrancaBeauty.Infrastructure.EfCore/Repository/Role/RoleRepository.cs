using Framework.Infrastructure;
using PrancaBeauty.Domain.User.RoleAgg.Contracts;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Role
{
    public class RoleRepository : BaseRepository<TblRole>, IRoleRepository
    {
        public RoleRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
