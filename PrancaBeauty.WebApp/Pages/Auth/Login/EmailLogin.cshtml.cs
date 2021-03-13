using Framework.Application.Consts;
using Framework.Common.ExMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Authentication.Jwt;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Localization;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth.Login
{
    public class EmailLoginModel : PageModel
    {
        private readonly ILocalizer _localizer;
        private readonly IJwtBuilder _jwtBuilder;
        private readonly IUserApplication _userApplication;

        public EmailLoginModel(ILocalizer localizer, IJwtBuilder jwtBuilder, IUserApplication userApplication)
        {
            _localizer = localizer;
            _jwtBuilder = jwtBuilder;
            _userApplication = userApplication;
        }



        public async Task<IActionResult> OnGetAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return StatusCode(400);

            string decryptedToken = token.AesDecrypt(AuthConst.SecretKey);
            string userId = decryptedToken.Split(", ")[0];
            string password = decryptedToken.Split(", ")[1];
            string ip = decryptedToken.Split(", ")[2];
            string date = decryptedToken.Split(", ")[3];
            bool remmeberMe = bool.Parse(decryptedToken.Split(", ")[4]);

            var result = await _userApplication
                .LoginByEmailLinkStep2Async(userId, password, ip,
                    HttpContext.Connection.RemoteIpAddress?.ToString(),
                    DateTime.Parse(date));
            if (result.IsSucceed)
            {
                string generatedToken = await _jwtBuilder.CreateTokenAync(result.Message);

                Response.CreateAuthCookie(generatedToken, remmeberMe);

                ViewData["Message"] = _localizer["LoginEmailSuccess"];
                ViewData["MsgType"] = "success";
                return Page();
            }
            else
            {
                ViewData["Message"] = _localizer[result.Message];
                ViewData["MsgType"] = "danger";
                return Page();
            }
        }
    }
}
