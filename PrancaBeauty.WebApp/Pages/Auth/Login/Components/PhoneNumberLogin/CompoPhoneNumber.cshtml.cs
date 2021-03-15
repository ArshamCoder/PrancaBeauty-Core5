using Framework.Application.Services.Sms;
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
        private readonly ISmsSender _smsSender;

        public CompoPhoneNumberModel(IMsgBox msgBox, ILocalizer localizer, IUserApplication userApplication, ISmsSender smsSender)
        {
            _msgBox = msgBox;
            _localizer = localizer;
            _userApplication = userApplication;
            _smsSender = smsSender;
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
                var isSend = _smsSender.SendLoginCode(Input.PhoneNumber, result.Message);
                if (isSend)
                    return _msgBox.SuccessMsg(_localizer["LoginCodeIsSent"], "GotoOtpPage()");
                else
                    return _msgBox.FaildMsg(_localizer["SmsSenderNotRespond"]);
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[result.Message]);
            }


        }

    }
}
