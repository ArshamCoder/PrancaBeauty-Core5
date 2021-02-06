using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.User
{
    public class UserRepository : BaseRepository<TblUser>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
