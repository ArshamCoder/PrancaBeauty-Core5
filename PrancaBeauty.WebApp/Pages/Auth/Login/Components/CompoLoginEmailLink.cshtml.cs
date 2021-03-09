using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class CompoLoginEmailLinkModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly IUserApplication _userApplication;

        public CompoLoginEmailLinkModel(IMsgBox msgBox, IUserApplication userApplication)
        {
            _msgBox = msgBox;
            _userApplication = userApplication;
        }

        [BindProperty]
        public ViCompoLoginEmailLinkModel Input { get; set; }


        public IActionResult OnGet(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "/Auth/User/Index";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            return Page();
        }


    }
}
