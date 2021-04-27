using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Contracts.AccessLevel;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels
{
    [Authorize(Roles = Roles.CanViewListAccessLevel)]
    public class ListModel : PageModel
    {
        private readonly IAccesslevelApplication _accesslevelApplication;
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;

        public ListModel(IAccesslevelApplication accesslevelApplication, IMsgBox msgBox, ILocalizer localizer)
        {
            _accesslevelApplication = accesslevelApplication;
            _msgBox = msgBox;
            _localizer = localizer;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostReadDataAsync([DataSourceRequest] DataSourceRequest request)
        {
            var qData = await _accesslevelApplication.GetListForAdminPageAsync(null, request.Page, request.PageSize);


            var dataGrid = await qData.Item2.ToDataSourceResultAsync(request);
            dataGrid.Total = (int)qData.Item1.CountAllItem;
            dataGrid.Data = qData.Item2;

            return new JsonResult(dataGrid);
        }

        public async Task<IActionResult> OnPostRemoveAsync(string Id)
        {
            if (!User.IsInRole(Roles.CanRemoveAccessLevel))
                return _msgBox.FaildMsg("");

            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());

            var result = await _accesslevelApplication.RemoveAsync(new InpRemove
            {
                Id = Id
            });

            if (result.IsSucceed)
            {

            }
            else
            {
                return _msgBox.ModelStateMsg(_localizer[result.Message]);
            }

            return Page();
        }

    }
}
