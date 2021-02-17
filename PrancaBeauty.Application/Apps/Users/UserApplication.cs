using Framework.Infrastructure;
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
        private readonly ILogger _logger;

        public UserApplication(IUserRepository userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
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
                    AccessLevelId = Guid.Empty,
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

    }



}
