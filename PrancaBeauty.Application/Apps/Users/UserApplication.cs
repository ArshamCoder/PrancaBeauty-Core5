using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Users
{
    /*
     * همیشه باید از
     * userApplication
     * به
     * UserRepository
     * دسترسی داشته باشیم
     */

    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccesslevelApplication _accesslevelApplication;
        private readonly ILogger _logger;

        public UserApplication(IUserRepository userRepository, ILogger logger, IAccesslevelApplication accesslevelApplication)
        {
            _userRepository = userRepository;
            _logger = logger;
            _accesslevelApplication = accesslevelApplication;
        }

        public async Task<OperationResult> AddUserAsync(InpAddUser input)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(input.Email))
                    throw new ArgumentNullException("Email cant be null.");

                if (string.IsNullOrWhiteSpace(input.PhoneNumber))
                    throw new ArgumentNullException("PhoneNumber cant be null.");

                if (string.IsNullOrWhiteSpace(input.FirstName))
                    throw new ArgumentNullException("FirstName cant be null.");

                if (string.IsNullOrWhiteSpace(input.LastName))
                    throw new ArgumentNullException("LastName cant be null.");

                if (string.IsNullOrWhiteSpace(input.Password))
                    throw new ArgumentNullException("Password cant be null.");

                TblUser tUser = new TblUser()
                {
                    Date = DateTime.Now,
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    AccessLevelId = Guid.Parse(await _accesslevelApplication.GetIdByNameAsync("Users")),
                    IsActive = true,
                    PhoneNumber = input.PhoneNumber,
                    UserName = input.Email
                };
                var result = await _userRepository.CreateUserAsync(tUser, input.Password);
                if (result.Succeeded)
                {
                    if (_userRepository.RequireConfirmEmail())
                    {
                        /*
                         * code = 1
                         * یعنی کاربر ثبت نام کرده و باید ایمیلش هم تایید کند
                         */
                        return new OperationResult().Succeed(1, tUser.Id.ToString());

                    }
                    else
                    {
                        //کاربر نیاز به تایید ایمیل ندارد
                        return new OperationResult().Succeed("UserCreatedSuccessfully");
                    }

                }
                else
                {
                    return new OperationResult().Failed(string.Join(", ", result.Errors.Select(x => x.Description)));
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");

            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            //تولید ایمیل فعال سازی
            var qUser = await _userRepository.FindByIdAsync(userId);
            return await _userRepository.GenerateEmailConfirmationTokenAsync(qUser);
        }

        public async Task<OperationResult> EmailConfirmationAsync(string userId, string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentNullException("UserId can`t be null.");

                if (string.IsNullOrWhiteSpace(token))
                    throw new ArgumentNullException("Token can`t be null.");

                //آیا ایمیل کاربر تایید شده است
                if (await IsEmailConfirmedAsync(userId))
                    return new OperationResult().Failed("EmailAlreadyVerified");


                var qUser = await _userRepository.FindByIdAsync(userId);

                var result = await _userRepository.EmailConfirmationAsync(qUser, token);
                if (result.Succeeded)
                {
                    return new OperationResult().Succeed("EmailConfirmationSuccesfully");
                }
                else
                {
                    return new OperationResult().Failed(string.Join(", ", result.Errors.Select(a => a.Description)));
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OperationResult> LoginByUserNamePasswordAsync(string userName, string pawword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    throw new ArgumentNullException("UserName cant be null.");

                if (string.IsNullOrWhiteSpace(pawword))
                    throw new ArgumentNullException("Pawword cant be null.");

                var userId = await _userRepository.GetUserIdByUserNameAsync(userName);

                return await LoginAsync(userId, pawword);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OperationResult> LoginByEmailLinkStep1Async(string email)
        {
            try
            {
                // لایگن با لینک یکبار مصرف
                // مرحله اول
                // ارسال لینک به ایمیل کاربر


                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException("Email cant be null.");

                var qUser = await GetUserByEmailAsync(email);

                if (qUser == null)
                    return new OperationResult().Failed("EmailNotFound");

                if (qUser.EmailConfirmed == false)
                    return new OperationResult().Failed("PleaseConfirmYourEmail");

                if (qUser.IsActive == false)
                    return new OperationResult().Failed("YourAccountIsDisabled");

                #region حذف پسورد قبلی کاربر
                if (await _userRepository.HasPasswordAsync(qUser))
                {
                    var result = await _userRepository.RemovePasswordAsync(qUser);
                    if (!result.Succeeded)
                    {
                        _logger.Error(string.Join(", ", result.Errors.Select(a => a.Description)));
                        return new OperationResult().Failed("EmailNotFound");
                    }
                }
                #endregion

                #region تنظیم پسورد جدید برای کاربر
                string newPassword = new Random().Next(100000, 999999).ToString();
                var addPassResult = await _userRepository.AddPasswordAsync(qUser, newPassword);
                if (!addPassResult.Succeeded)
                {
                    _logger.Error(string.Join(", ", addPassResult.Errors.Select(a => a.Description)));
                    return new OperationResult().Failed("EmailNotFound");
                }
                #endregion




                return new OperationResult().Succeed(qUser.Id + ", " + newPassword);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OperationResult> LoginByEmailLinkStep2Async(string userId, string password)
        {
            return await LoginAsync(userId, password);
        }

        public async Task<OperationResult> LoginAsync(string userId, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentNullException("UserId cant be null.");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("Password cant be null.");

                var qUser = await _userRepository.FindByIdAsync(userId);

                if (qUser == null)
                    return new OperationResult().Failed("");

                if (qUser.EmailConfirmed == false)
                    return new OperationResult().Failed("");

                if (qUser.IsActive == false)
                    return new OperationResult().Failed("");

                var result = await _userRepository.PasswordSignInAsync(qUser, password, true, true);
                if (result.Succeeded)
                {
                    return new OperationResult().Succeed(qUser.Id.ToString());
                }
                else
                {
                    if (result.IsLockedOut)
                        return new OperationResult().Failed("UserIsLockedOut");
                    else if (result.IsNotAllowed)
                        return new OperationResult().Failed("UserIsLockedOut");
                    else
                        return new OperationResult().Failed("UserNameOrPasswordIsInvalid");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<bool> IsEmailConfirmedAsync(string userId)
        {
            var qUser = await _userRepository.FindByIdAsync(userId);

            return await _userRepository.IsEmailConfirmedAsync(qUser);
        }


        public async Task<OutGetAllUserDetails> GetAllUserDetailsAsync(string UserId)
        {
            try
            {
                var qData = await _userRepository.Get
                    .Where(a => a.Id == Guid.Parse(UserId))
                    .Select(a => new OutGetAllUserDetails
                    {
                        Id = a.Id.ToString(),
                        UserName = a.UserName,
                        Email = a.Email,
                        PhoneNumber = a.PhoneNumber,
                        AccessLevelId = a.AccessLevelId.ToString(),
                        AccessLevelTitle = a.TblAccessLevels.Name,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Date = a.Date,
                        IsActive = a.IsActive
                    })
                    .SingleOrDefaultAsync();

                if (qData == null)
                    return null;


                return qData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<TblUser> GetUserByIdAsync(string userId)
        {
            try
            {
                return await _userRepository.FindByIdAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }



        public async Task<TblUser> GetUserByEmailAsync(string email)
        {
            var qUser = await _userRepository.FindByEmailAsync(email);
            return qUser;
        }

        public async Task<bool> RemoveUnConfirmedUserAsync(string email)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException("UserId cant be null.");

                var qUser = await GetUserByEmailAsync(email);
                if (qUser == null)
                    return true;

                if (qUser.EmailConfirmed)
                    return true;

                var result = await _userRepository.DeleteAsync(qUser);
                if (result.Succeeded)
                    return true;
                else
                    throw new Exception(string.Join(", ", result.Errors.Select(a => a.Code + "-" + a.Description)));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }


    }



}
