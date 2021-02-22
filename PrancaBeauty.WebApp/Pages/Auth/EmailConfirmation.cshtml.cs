using Framework.Application.Consts;
using Framework.Common.ExMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using System;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class EmailConfirmationModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        public EmailConfirmationModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public async Task<IActionResult> OnGetAsync(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return Page();


                var decryptToken = token.AesDecrypt(AuthConst.SecretKey);

                string userId = decryptToken.Split(", ")[0];
                string _token = decryptToken.Split(", ")[1];

                var result = await _userApplication.EmailConfirmationAsync(userId, _token);
                return Page();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
