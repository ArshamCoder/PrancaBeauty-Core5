using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.User.EditProfile.Components.ChangePassword
{
    [Authorize]
    public class Compo_ChangePasswordModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IUserApplication _userApplication;
        public Compo_ChangePasswordModel(IUserApplication userApplication, IMsgBox msgBox, ILocalizer localizer)
        {
            _userApplication = userApplication;
            _msgBox = msgBox;
            _localizer = localizer;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            string UserId = User.GetUserDetails().UserId;

            var Result = await _userApplication.ChanagePasswordAsync(UserId, Input.CurrentPassword, Input.NewPassword);
            if (Result.IsSucceed)
            {
                return _msgBox.SuccessMsg(_localizer[Result.Message]);
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[Result.Message].Replace(", ", "<br/>"));
            }
        }

        [BindProperty]
        public ViCompo_ChangePassword Input { get; set; }

    }
}
