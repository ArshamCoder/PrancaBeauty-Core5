using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.Users.Componenets
{
    public class CompoChanageAccessLevelModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IUserApplication _userApplication;
        private readonly IAccesslevelApplication _accesslevelApplication;

        public CompoChanageAccessLevelModel(IMsgBox msgBox, ILocalizer localizer, IUserApplication userApplication, IAccesslevelApplication accesslevelApplication)
        {
            _msgBox = msgBox;
            _localizer = localizer;
            _userApplication = userApplication;
            _accesslevelApplication = accesslevelApplication;
        }

        [BindProperty(SupportsGet = true)]
        public ViCompoChanageAccessLevel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<JsonResult> OnGetReadAsync(string Text)
        {
            var qData = await _accesslevelApplication.GetForChangeUserAccesssLevelAsync(Text);
            return new JsonResult(qData);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _userApplication
                .ChanageUserAccessLevelAsync(Input.UserId, User.GetUserDetails().UserId, Input.AccessLevelId);
            if (result.IsSucceed)
            {
                // بعد از تغییر سطح دسترسی کاربر از سایت باید خارج شود
                // و بعدش دوباره لاگین کند
                CacheUsersToRebuildToken.Add(Input.UserId);

                return _msgBox.SuccessMsg(_localizer[result.Message], "Close(); RefreshData();");
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[result.Message]);
            }
        }
    }
}
