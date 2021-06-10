using a;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;

namespace PrancaBeauty.WebApp.Pages.User.EditProfile
{
    public class EditProfileModel : PageModel
    {

        private readonly IMsgBox _MsgBox;
        private readonly IUserApplication _UserApplication;
        public EditProfileModel(IUserApplication userApplication, IMsgBox msgBox)
        {
            _UserApplication = userApplication;
            _MsgBox = msgBox;
        }

        [BindProperty]
        public ViEditProfile Input { get; set; }
        public void OnGet()
        {
        }
    }
}
