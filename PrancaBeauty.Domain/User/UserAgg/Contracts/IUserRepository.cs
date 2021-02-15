using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System.Threading.Tasks;

namespace PrancaBeauty.Domain.User.UserAgg.Contracts
{
    public interface IUserRepository : IRepository<TblUser>
    {
        Task<IdentityResult> CreateUserAsync(TblUser user, string password);
    }
}
