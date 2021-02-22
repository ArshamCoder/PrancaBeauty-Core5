using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Contracts.Users;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Users
{
    public interface IUserApplication
    {
        Task<OperationResult> AddUserAsync(InpAddUser input);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task<OperationResult> EmailConfirmationAsync(string userId, string token);
        Task<bool> IsEmailConfirmedAsync(string userId);
    }
}
