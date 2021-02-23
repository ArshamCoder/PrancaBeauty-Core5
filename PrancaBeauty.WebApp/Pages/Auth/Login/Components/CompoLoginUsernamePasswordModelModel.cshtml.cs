using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class CompoLoginUsernamePasswordModelModel : PageModel
    {
        public CompoLoginUsernamePasswordModelModel()
        {

        }

        [BindProperty]
        public ViCompoLoginUsernamePasswordModel Input { get; set; }

        public IActionResult OnGet(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return Page();
        }
    }
}
