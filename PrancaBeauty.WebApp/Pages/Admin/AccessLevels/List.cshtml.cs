using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.AccessLevels
{
    public class ListModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task OnPostReadDataAsync()
        {

        }

    }
}
