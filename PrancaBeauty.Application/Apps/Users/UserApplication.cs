using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.Logger.Contracts;
using System;
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
                return new OperationResult();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");

            }
        }
    }



}
