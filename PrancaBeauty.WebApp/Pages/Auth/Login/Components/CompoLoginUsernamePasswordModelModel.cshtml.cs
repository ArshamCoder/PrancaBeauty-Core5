using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Authentication.Jwt;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Common.Utilities.Types;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class CompoLoginUsernamePasswordModelModel : PageModel
    {
        private readonly IUserApplication _userApplication;
        private readonly IMsgBox _msgBox;
        private readonly IJwtBuilder _jwtBuilder;
        private readonly ILocalizer _localizer;
        public CompoLoginUsernamePasswordModelModel(IUserApplication userApplication, IMsgBox msgBox, IJwtBuilder jwtBuilder, ILocalizer localizer)
        {
            _userApplication = userApplication;
            _msgBox = msgBox;
            _jwtBuilder = jwtBuilder;
            _localizer = localizer;
        }

        [BindProperty]
        public ViCompoLoginUsernamePasswordModel Input { get; set; }

        public IActionResult OnGet()
        {

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());


            var result = await _userApplication.LoginByUserNamePasswordAsync(Input.Email, Input.Password);

            if (result.IsSucceed)
            {
                // result.Message == userId
                string generatedToken = await _jwtBuilder.CreateTokenAync(result.Message);

                Response.CreateAuthCookie(generatedToken, Input.RemmeberMe);



                return new JsResult("GotoReturnUrl()");
            }
            else
            {
                return _msgBox.InfoMsg(_localizer[result.Message]);
            }




        }
    }
}
