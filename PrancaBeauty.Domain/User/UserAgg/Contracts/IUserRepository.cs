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
        Task<SignInResult> PasswordSignInAsync(TblUser user, string password, bool isPersistent, bool lockoutOnFailure);
        Task<string> GetUserIdByUserNameAsync(string userName);
        Task<string> GetUserIdByEmailAsync(string email);
        Task<string> GetUserIdByPhoneNumberAsync(string phoneNumber);
        Task<TblUser> FindByEmailAsync(string email);
        Task<IdentityResult> DeleteAsync(TblUser entity);
        Task<bool> HasPasswordAsync(TblUser user);
        Task<IdentityResult> RemovePasswordAsync(TblUser entity);
        Task<IdentityResult> AddPasswordAsync(TblUser entity, string password);
        Task<IdentityResult> RemovePhoneNumberPasswordAsync(TblUser entity);
        Task<IdentityResult> AddPhoneNumberPasswordAsync(TblUser entity, string password);
        Task<TblUser> FindByPhoneNumberAsync(string phoneNumber);
    }
}
