using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Users
{
    public interface IUserApplication
    {
        Task<OperationResult> AddUserAsync(InpAddUser input);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task<OperationResult> EmailConfirmationAsync(string userId, string token);
        Task<OperationResult> LoginByUserNamePasswordAsync(string userName, string pawword);
        Task<OperationResult> LoginByEmailLinkStep1Async(string email, string ip);
        Task<OperationResult> LoginByEmailLinkStep2Async(string userId, string password, string linkIp, string userIp, DateTime date);
        Task<OperationResult> LoginByPhoneNumberStep1Async(string phoneNumber);
        Task<OperationResult> LoginByPhoneNumberStep2Async(string phoneNumber, string code);
        Task<OperationResult> LoginAsync(string userId, string password);
        Task<bool> IsEmailConfirmedAsync(string userId);

        Task<OutGetAllUserDetails> GetAllUserDetailsAsync(string UserId);
        Task<TblUser> GetUserByIdAsync(string userId);
        Task<TblUser> GetUserByEmailAsync(string email);
        Task<bool> RemoveUnConfirmedUserAsync(string email);

        Task<TblUser> GetUserByPhoneNumberAsync(string phoneNumber);
    }
}
