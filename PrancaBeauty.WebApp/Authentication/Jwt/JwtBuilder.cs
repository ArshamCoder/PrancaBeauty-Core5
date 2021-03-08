using Framework.Application.Consts;
using Framework.Common.ExMethod;
using Microsoft.IdentityModel.Tokens;
using PrancaBeauty.Application.Apps.Role;
using PrancaBeauty.Application.Apps.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Authentication.Jwt
{
    public class JwtBuilder : IJwtBuilder
    {
        private readonly IUserApplication _userApplication;
        private readonly IRoleApplication _roleApplication;



        public JwtBuilder(IUserApplication userApplication, IRoleApplication roleApplication)
        {
            _userApplication = userApplication;
            _roleApplication = roleApplication;
        }

        public async Task<string> CreateTokenAync(string userId)
        {
            var userDetails = await _userApplication.GetAllUserDetailsAsync(userId);
            if (userDetails == null)
                throw new Exception();

            var userRoles = await _roleApplication.GetRolesByUserAsync(await _userApplication.GetUserByIdAsync(userId));
            if (userRoles == null)
                throw new Exception();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userDetails.Id.ToString()),
                new Claim(ClaimTypes.Name, userDetails.UserName),
                new Claim(ClaimTypes.Email, userDetails.Email),
                new Claim(ClaimTypes.MobilePhone, userDetails.PhoneNumber??""),
                new Claim(ClaimTypes.GivenName, userDetails.FirstName),
                new Claim(ClaimTypes.Surname, userDetails.LastName),
                new Claim("AccessLevel", userDetails.AccessLevelTitle),
                new Claim("Date", userDetails.Date.ToString("yyyy/MM/dd HH:mm:ss")),
            };

            // اسم سطح دسترسی های کاربر را به کلیم اضافه میکند
            // ممکنه یک سطح دسترسی باشه یا چندتا فرقی نمیکند
            claims.AddRange(userRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


            // ایجاد توکن برای ورود به سایت
            var key = Encoding.ASCII.GetBytes(AuthConst.SecretCode);
            var tokenDescreptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = AuthConst.Issuer,
                Audience = AuthConst.Audience,
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(48)
            };

            var securityToken = new JwtSecurityTokenHandler().CreateToken(tokenDescreptor);
            string generatedToken = "Bearer " + new JwtSecurityTokenHandler().WriteToken(securityToken);

            return generatedToken.AesEncrypt(AuthConst.SecretKey);
        }

    }
}
