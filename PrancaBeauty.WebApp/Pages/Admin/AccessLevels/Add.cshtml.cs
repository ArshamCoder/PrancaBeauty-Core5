using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels
{
    [Authorize(Roles = Roles.CanAddAccessLevel)]
    public class AddModel : PageModel
    {

        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IAccesslevelApplication _accesslevelApplication;

        public AddModel(IAccesslevelApplication accesslevelApplication, IMsgBox msgBox, ILocalizer localizer)
        {
            _accesslevelApplication = accesslevelApplication;
            _msgBox = msgBox;
            _localizer = localizer;
        }


        [BindProperty]
        public ViAddAccessLevel Input { get; set; }
        public IActionResult OnGet(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl ?? $"/{CultureInfo.CurrentCulture.Parent.Name}/Admin/AccessLevel/List";
            return Page();
        }




        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            var result = await _accesslevelApplication.AddNewAsync(new InpAddNewAccessLevel()
            {
                Name = Input.Name,
                Roles = Input.Roles
            });

            if (result.IsSucceed)
            {
                return _msgBox.SuccessMsg(_localizer[result.Message], "GotoList()");
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[result.Message]);
            }
        }

    }
}
