using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace PrancaBeauty.WebApp.Pages.Auth.Login
{
    public class LoginModel : PageModel
    {
        public IActionResult OnGet(string ReturnUrl = null)
        {
            ViewData["ReturnUrl"] = ReturnUrl ?? $"/{CultureInfo.CurrentCulture.Parent.Name}/User/Index";
            return Page();
        }
    }
}
