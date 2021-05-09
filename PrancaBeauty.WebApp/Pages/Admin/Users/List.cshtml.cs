using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.Users
{
    [Authorize(Roles = Roles.CanViewListUsers)]
    public class ListModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IUserApplication _usersApplication;

        public ListModel(IMsgBox msgBox, ILocalizer localizer, IUserApplication usersApplication)
        {
            _msgBox = msgBox;
            _localizer = localizer;
            _usersApplication = usersApplication;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostReadDataAsync([DataSourceRequest] DataSourceRequest request,
            string FullName, string Email, string PhoneNumber, string FieldSort)
        {
            var qData = await _usersApplication
                .GetListForAdminPageAsync(Email, PhoneNumber, FullName, FieldSort, request.Page, request.PageSize);

            var items = qData.Item2
                .Select(a => new VmListUsers
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    AccessLevelName = a.AccessLevelName,
                    Date = a.Date.ToString("yyyy/MM/dd HH:mm"),
                    Email = a.Email,
                    IsActive = a.IsActive,
                    IsEmailConfirmed = a.IsEmailConfirmed,
                    IsPhoneNumberConfirmed = a.IsPhoneNumberConfirmed,
                    PhoneNumber = a.PhoneNumber
                });

            var _DataGrid = items.ToDataSourceResult(request);

            _DataGrid.Total = (int)qData.Item1.CountAllItem;
            _DataGrid.Data = items;

            return new JsonResult(_DataGrid);
        }
    }
}
