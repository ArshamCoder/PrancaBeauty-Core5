using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Globalization;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels
{
    [Authorize(Roles = Roles.CanAddAccessLevel)]
    public class AddModel : PageModel
    {
        [BindProperty]
        public ViAddAccessLevel Input { get; set; }
        public IActionResult OnGet(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl ?? $"/{CultureInfo.CurrentCulture.Parent.Name}/Admin/AccessLevel/List";
            return Page();
        }


    }
}
