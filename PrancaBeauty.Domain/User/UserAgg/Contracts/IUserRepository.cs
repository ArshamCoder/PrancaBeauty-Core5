using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System.Threading.Tasks;

namespace PrancaBeauty.Domain.User.UserAgg.Contracts
{
    public interface IUserRepository : IRepository<TblUser>
    {
        Task<IdentityResult> CreateUserAsync(TblUser user, string password);
        Task<string> GenerateEmailConfirmationTokenAsync(TblUser user);
        Task<TblUser> FindByIdAsync(string userId);
        bool RequireConfirmEmail();

        Task<IdentityResult> EmailConfirmationAsync(TblUser user, string token);
        Task<bool> IsEmailConfirmedAsync(TblUser user);
    }
}
