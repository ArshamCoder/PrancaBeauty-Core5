using Framework.Application.Services.Sms;
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

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components.PhoneNumberLogin
{
    public class CompoLoginPhoneNumberOtpModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly IUserApplication _userApplication;

        private readonly ILocalizer _localizer;
        private readonly IJwtBuilder _jwtBuilder;
        private readonly ISmsSender _smsSender;

        public CompoLoginPhoneNumberOtpModel(IMsgBox msgBox, IUserApplication userApplication, ILocalizer localizer, IJwtBuilder jwtBuilder, ISmsSender smsSender)
        {
            _msgBox = msgBox;
            _userApplication = userApplication;
            _localizer = localizer;
            _jwtBuilder = jwtBuilder;
            _smsSender = smsSender;
        }



        [BindProperty(SupportsGet = true)]
        public ViCompoLoginPhoneNumberOtpModel Input { get; set; }

        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            var result = await _userApplication.LoginByPhoneNumberStep2Async(Input.PhoneNumber, Input.Code);
            if (result.IsSucceed)
            {
                string generatedToken = await _jwtBuilder.CreateTokenAync(result.Message);
                Response.CreateAuthCookie(generatedToken, Input.RemmeberMe);

                return new JsResult("GotoReturnUrl()");
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[result.Message]);
            }

        }


        public async Task<IActionResult> OnPostResendAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return _msgBox.ModelStateMsg(_localizer["PhoneNumberCantBeNull"]);

            var qUser = await _userApplication.GetUserByPhoneNumberAsync(phoneNumber);
            if (qUser == null)
                return _msgBox.ModelStateMsg(_localizer["PhoneNumberIsInvalid"]);

            var result = await _userApplication.ReCreatePasswordAsync(qUser);
            if (result.IsSucceed)
            {
                var isSend = _smsSender.SendLoginCode(Input.PhoneNumber, result.Message);
                if (isSend)
                    return _msgBox.SuccessMsg(_localizer["LoginCodeIsSent"], "StartTimer()");
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
