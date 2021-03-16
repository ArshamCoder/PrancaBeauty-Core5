using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components.PhoneNumberLogin
{
    public class CompoLoginPhoneNumberOtpModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly IUserApplication _userApplication;

        public CompoLoginPhoneNumberOtpModel(IMsgBox msgBox, IUserApplication userApplication)
        {
            _msgBox = msgBox;
            _userApplication = userApplication;
        }

        [BindProperty(SupportsGet = true)]
        public ViCompoLoginPhoneNumberOtpModel Input { get; set; }

        public IActionResult OnGet(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "/Auth/User/Index";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            var result = await _userApplication.LoginByPhoneNumberStep2Async(Input.PhoneNumber, Input.Code);
            return Page();

        }


    }
}
