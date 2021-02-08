using Framework.Infrastructure;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.User
{
    public class UserRepository : BaseRepository<TblUser>, IUserRepository
    {
        public UserRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
