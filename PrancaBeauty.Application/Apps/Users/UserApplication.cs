using Framework.Infrastructure;
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

        public async Task<bool> IsEmailConfirmedAsync(string userId)
        {
            var qUser = await _userRepository.FindByIdAsync(userId);

            return await _userRepository.IsEmailConfirmedAsync(qUser);
        }

    }



}
