using Framework.Application.Consts;
using Framework.Application.Services.Email;
using Framework.Common.ExMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Apps.Template;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Framework.Infrastructure;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class CompoLoginEmailLinkModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly IUserApplication _userApplication;
        private readonly ISettingApplication _settingApplication;
        private readonly IEmailSender _emailSender;
        private readonly ILocalizer _localizer;
        private readonly ITemplateApplication _templateApplication;

        public CompoLoginEmailLinkModel(IMsgBox msgBox, IUserApplication userApplication, ISettingApplication settingApplication, IEmailSender emailSender, ILocalizer localizer, ITemplateApplication templateApplication)
        {
            _msgBox = msgBox;
            _userApplication = userApplication;
            _settingApplication = settingApplication;
            _emailSender = emailSender;
            _localizer = localizer;
            _templateApplication = templateApplication;
        }

        [BindProperty]
        public ViCompoLoginEmailLinkModel Input { get; set; }


        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            Thread.Sleep(3000);

            var result = await _userApplication.LoginByEmailLinkStep1Async(Input.Email, HttpContext.Connection.RemoteIpAddress?.ToString());
            if (result.IsSucceed)
            {
                string token = (result.Message + ", " + Input.RemmeberMe).AesEncrypt(AuthConst.SecretKey);


                string url = (await _settingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl
                              + $"/EmailLogin?token={WebUtility.UrlEncode(token)}";

                await _emailSender.SendAsync(Input.Email, _localizer["EmailLoginSubject"],
                    await _templateApplication.GetEmailLoginTemplateAsync(CultureInfo.CurrentCulture.Name, url));

                return _msgBox.SuccessMsg(_localizer["EmailLoginSent"], "location.href='/';");
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[result.Message]);
            }



        }


    }
}
