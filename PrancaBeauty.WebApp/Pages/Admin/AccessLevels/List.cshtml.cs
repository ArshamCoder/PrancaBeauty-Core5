using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Accesslevel;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels
{
    public class ListModel : PageModel
    {
        private readonly IAccesslevelApplication _accesslevelApplication;

        public ListModel(IAccesslevelApplication accesslevelApplication)
        {
            _accesslevelApplication = accesslevelApplication;
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

    }
}
