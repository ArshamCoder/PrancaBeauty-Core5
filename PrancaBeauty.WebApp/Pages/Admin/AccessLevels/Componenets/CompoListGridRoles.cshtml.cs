using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Role;
using PrancaBeauty.WebApp.Models.ViewInput;
using PrancaBeauty.WebApp.Models.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels.Componenets
{
    public class CompoListGridRolesModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public CompoListGridRolesModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
        [BindProperty(SupportsGet = true)]
        public ViCompoListGridRolesModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Input.AccessLevelId != null)
            {
                // ویرایش
                return Page();
            }
            else
            {

                return Page();
            }
        }

        public async Task<JsonResult> OnPostReadAsync([DataSourceRequest] DataSourceRequest request, string parentId = null)
        {
            var qData = (await _roleApplication.ListOfRolesAsync(parentId))
                .Select(a => new VmCompoListGridRolesModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    HasChild = a.HasChild,
                    PageName = a.PageName,
                    ParentId = a.ParentId,
                    Sort = a.Sort
                });

            return new JsonResult(await qData.ToDataSourceResultAsync(request));
        }

    }
}
