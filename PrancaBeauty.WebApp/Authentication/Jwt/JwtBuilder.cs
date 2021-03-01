using PrancaBeauty.Application.Apps.Users;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Authentication.Jwt
{
    public class JwtBuilder : IJwtBuilder
    {
        private readonly IUserApplication _userApplication;

        public JwtBuilder(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public async Task<string> CreateTokenAync(string userId)
        {
            var _UserDetails = await _userApplication.GetAllUserDetailsAsync(userId);
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,_UserDetails.UserName)
            };
        }

    }
}
