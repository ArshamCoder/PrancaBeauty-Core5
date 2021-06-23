using Framework.Common.Utilities.Paging;
using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;
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
        Task<OperationResult> ReCreatePasswordAsync(TblUser user);
        Task<OperationResult> AddRolesAsync(TblUser user, string[] roles);
        Task<OperationResult> EditUsersRoleByAccIdAsync(string accessLevelId, string[] roles);
        Task<List<string>> GetUserIdsByAccIdAsync(string accessLevelId);

        Task<(OutPagingData, List<OutGetListForAdminPage>)>
            GetListForAdminPageAsync(string email, string phoneNumber, string fullName, string sort, int pageNum, int take);

        Task<OperationResult> RemoveUserAsync(string userId);
        Task<OperationResult> ChangeUserStatusAsync(string userId, string selfUserId);
        Task<OperationResult> ChanageUserAccessLevelAsync(string userId, string selfUserId, string accessLevelId);
        Task<OutGetUserDetailsForAccountSettings> GetUserDetailsForAccountSettingsAsync(string userId);
        Task<OperationResult> SaveAccountSettingUserDetailsAsync(string UserId, InpSaveAccountSettingUserDetails Input, string UrlToChangeEmail);
        Task<OperationResult> ChangeEmailAsync(string Token);
        Task<OperationResult> ReSendSmsCodeAsync(string phoneNumber);
        Task<OperationResult> PhoneConfirmationBySmsCodeAsync(string userId, string phoneNumber, string code);
    }
}
