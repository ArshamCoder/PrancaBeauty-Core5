using Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System.Threading.Tasks;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.User
{
    public class UserRepository : BaseRepository<TblUser>, IUserRepository
    {
        private readonly UserManager<TblUser> _userManager;

        public UserRepository(MainContext dbContext, UserManager<TblUser> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(TblUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<TblUser> FindByIdAsync(string userId)
        {
            return await _userManager.FindByEmailAsync(userId);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(TblUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public bool RequireConfirmEmail()
        {
            return _userManager.Options.SignIn.RequireConfirmedEmail;
        }
    }
}
