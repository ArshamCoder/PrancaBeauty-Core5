using Framework.Application.Consts;
using Framework.Common.ExMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Template;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Application.Services.Email;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {

        private readonly IUserApplication _userApplication;
        private readonly IEmailSender _emailSender;
        private readonly ILocalizer _Localizer;
        private readonly ITemplateApplication _templateApplication;

        public RegisterModel(IUserApplication userApplication, IEmailSender emailSender, ILocalizer localizer, ITemplateApplication templateApplication)
        {
            _userApplication = userApplication;
            _emailSender = emailSender;
            _Localizer = localizer;
            _templateApplication = templateApplication;
        }


        //  [BindProperty(SupportsGet = true)] // Get Data In Post And Get Method
        [BindProperty] // Get Data In Post Method
        public ViRegisterModel Input { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _userApplication.AddUserAsync(new InpAddUser()
            {
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Password = Input.Password
            });
            if (result.IsSucceed)
            {
                if (result.Code == 1)
                {
                    #region ارسال ایمیل تایید

                    string userId = result.Message;
                    var token = await _userApplication.GenerateEmailConfirmationTokenAsync(userId);
                    var encryptedToken = $"{userId}, {token}".AesEncrypt(AuthConst.SecretKey);

                    string siteUrl = "";
                    string url = $"{siteUrl}/Auth/EmailConfirmation?Token={WebUtility.UrlEncode(encryptedToken)}";

                    await _emailSender.SendAsync(Input.Email,
                        _Localizer["RegistrationEmailSubject"],
                        await _templateApplication.GetEmailConfirmationTemplateAsync(CultureInfo.CurrentCulture.Name, url));
                    #endregion

                    return Page();
                }
                else
                {
                    return Redirect("/Auth/UserCreatedSuccessfully");
                }


            }
            else
            {
                foreach (var item in result.Message.Split(", "))
                {
                    ModelState.AddModelError("", item);
                }

                return Page();
            }

            return Page();
        }
    }
}
