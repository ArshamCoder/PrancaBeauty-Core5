using Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Common.ExMethod;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.User
{
    public class UserRepository : BaseRepository<TblUser>, IUserRepository
    {
        private readonly UserManager<TblUser> _userManager;

        private readonly SignInManager<TblUser> _signInManager;

        public UserRepository(MainContext dbContext, UserManager<TblUser> userManager, SignInManager<TblUser> signInManager) : base(dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(TblUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<TblUser> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(TblUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public bool RequireConfirmEmail()
        {
            return _userManager.Options.SignIn.RequireConfirmedEmail;
        }


        public async Task<IdentityResult> EmailConfirmationAsync(TblUser user, string token)
        {
            if (user == null)
                throw new ArgumentNullException("User can`t be null.");

            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException("Token can`t be null.");

            return await _userManager.ConfirmEmailAsync(user, token);
        }



        public async Task<bool> IsEmailConfirmedAsync(TblUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(TblUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }

        public async Task<string> GetUserIdByUserNameAsync(string userName)
        {
            return await GetNoTraking.Where(a => a.UserName == userName).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            return await GetNoTraking.Where(a => a.Email == email).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }

        public async Task<string> GetUserIdByPhoneNumberAsync(string phoneNumber)
        {
            return await GetNoTraking.Where(a => a.PhoneNumber == phoneNumber).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }

        public async Task<TblUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> DeleteAsync(TblUser entity)
        {
            return await _userManager.DeleteAsync(entity);
        }


        public async Task<bool> HasPasswordAsync(TblUser user)
        {
            return await _userManager.HasPasswordAsync(user);
        }

        public async Task<IdentityResult> RemovePasswordAsync(TblUser user)
        {
            return await _userManager.RemovePasswordAsync(user);
        }

        public async Task<IdentityResult> AddPasswordAsync(TblUser entity, string password)
        {
            return await _userManager.AddPasswordAsync(entity, password);
        }

        public async Task<IdentityResult> RemovePhoneNumberPasswordAsync(TblUser entity)
        {
            entity.PasswordPhoneNumber = null;
            entity.LastTrySentSms = null;

            return await _userManager.UpdateAsync(entity);
        }


        public async Task<IdentityResult> AddPhoneNumberPasswordAsync(TblUser entity, string password)
        {
            entity.PasswordPhoneNumber = password.ToMd5();
            entity.LastTrySentSms = DateTime.Now;

            return await _userManager.UpdateAsync(entity);
        }

    }
}
