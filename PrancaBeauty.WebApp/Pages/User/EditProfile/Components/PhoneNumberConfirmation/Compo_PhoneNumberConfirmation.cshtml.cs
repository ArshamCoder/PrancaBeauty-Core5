using Framework.Application.Services.Sms;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.User.EditProfile.Components.PhoneNumberConfirmation
{
    public class Compo_PhoneNumberConfirmationModel : PageModel
    {
        private readonly IMsgBox _MsgBox;
        private readonly ILocalizer _Localizer;
        private readonly ISmsSender _SmsSender;
        private readonly IUserApplication _UserApplication;
        public Compo_PhoneNumberConfirmationModel(IMsgBox msgBox, IUserApplication userApplication, ILocalizer localizer, ISmsSender smsSender)
        {
            _MsgBox = msgBox;
            _UserApplication = userApplication;
            _Localizer = localizer;
            _SmsSender = smsSender;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrWhiteSpace(Input.PhoneNumber))
                return StatusCode(400);

            var result = await _UserApplication.ReSendSmsCodeAsync(Input.PhoneNumber);
            if (result.IsSucceed)
                return Page();
            else
            {
                ViewData["ErrMsg"] = _Localizer["PhoneNumberConfirmationCodeNotSent"];
                return Page();
            }
        }

        public async Task<IActionResult> OnPostResendAsync(string PhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                return _MsgBox.ModelStateMsg(_Localizer["PhoneNumberCantBeNull"]);

            var Result = await _UserApplication.ReSendSmsCodeAsync(PhoneNumber);
            if (Result.IsSucceed)
            {
                return _MsgBox.SuccessMsg(_Localizer[Result.Message], "StartTimer()");
            }
            else
            {
                return _MsgBox.FaildMsg(_Localizer[Result.Message]);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _MsgBox.ModelStateMsg(ModelState.GetErrors());

            var userId = User.GetUserDetails().UserId;
            var result = await _UserApplication.PhoneConfirmationBySmsCodeAsync(userId, Input.PhoneNumber, Input.Code);
            if (result.IsSucceed)
            {
                return _MsgBox.SuccessMsg(_Localizer[result.Message], "ReloadPage()");
            }
            else
            {
                return _MsgBox.FaildMsg(_Localizer[result.Message]);
            }
        }

        [BindProperty(SupportsGet = true)]
        public ViCompo_PhoneNumberConfirmation Input { get; set; }
    }
}
