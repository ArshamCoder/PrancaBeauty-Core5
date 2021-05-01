using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Contracts.AccessLevel;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels
{
    [Authorize(Roles = Roles.CanEditAccessLevel)]
    public class EditModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IAccesslevelApplication _accesslevelApplication;

        public EditModel(IMsgBox msgBox, ILocalizer localizer, IAccesslevelApplication accesslevelApplication)
        {
            _msgBox = msgBox;
            _localizer = localizer;
            _accesslevelApplication = accesslevelApplication;
        }

        [BindProperty(SupportsGet = true)]
        public ViEditAccessLevel Input { get; set; }


        public async Task<IActionResult> OnGetAsync(string ReturnUrl)
        {
            if (string.IsNullOrWhiteSpace(Input.Id))
                return StatusCode(400);

            var qData = await _accesslevelApplication.GetForEditAsync(Input.Id);

            if (qData == null)
                return StatusCode(404);

            Input.Id = qData.Id;
            Input.Name = qData.Name;


            ViewData["ReturnUrl"] = ReturnUrl ?? $"/{CultureInfo.CurrentCulture.Parent.Name}/Admin/AccessLevel/List";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            var Result = await _accesslevelApplication.UpdateAsync(new InpUpdateAccessLevel()
            {
                Id = Input.Id,
                Name = Input.Name,
                Roles = Input.Roles
            });
            if (Result.IsSucceed)
            {
                return _msgBox.SuccessMsg(_localizer[Result.Message], "GotoList()");
            }
            else
            {
                return _msgBox.FaildMsg(_localizer[Result.Message]);
            }
        }



    }
}
