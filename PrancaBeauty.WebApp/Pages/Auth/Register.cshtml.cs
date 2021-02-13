using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        //  [BindProperty(SupportsGet = true)] // Get Data In Post And Get Method
        [BindProperty] // Get Data In Post Method
        public ViRegisterModel Input { get; set; }
        public RegisterModel()
        {

        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            return Page();
        }
    }
}
