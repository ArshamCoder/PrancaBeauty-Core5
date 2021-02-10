using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        public ViRegisterModel Input { get; set; }
        public RegisterModel()
        {

        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
