using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Users
{
    public interface IUserApplication
    {
        Task<OperationResult> AddUserAsync(InpAddUser input);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task<OperationResult> EmailConfirmationAsync(string userId, string token);
        Task<OperationResult> LoginByUserNamePasswordAsync(string userName, string pawword);
        Task<bool> IsEmailConfirmedAsync(string userId);

        Task<OutGetAllUserDetails> GetAllUserDetailsAsync(string UserId);
        Task<TblUser> GetUserAsync(string userId);
    }
}
