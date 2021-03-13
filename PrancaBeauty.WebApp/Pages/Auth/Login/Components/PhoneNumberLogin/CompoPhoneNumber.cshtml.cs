using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components.PhoneNumberLogin
{
    public class CompoPhoneNumberModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IUserApplication _userApplication;

        public CompoPhoneNumberModel(IMsgBox msgBox, ILocalizer localizer, IUserApplication userApplication)
        {
            _msgBox = msgBox;
            _localizer = localizer;
            _userApplication = userApplication;
        }

        [BindProperty]
        public ViCompoLoginPhoneNumberModel Input { get; set; }


        public IActionResult OnGet(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "/Auth/User/Index";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            var result = await _userApplication.LoginByPhoneNumberStep1Async(Input.PhoneNumber);
            if (result.IsSucceed)
            {

            }
            else
            {
                return _msgBox.FaildMsg(_localizer[result.Message]);
            }

            return Page();
        }

    }
}
