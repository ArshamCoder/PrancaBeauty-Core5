using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Infrastructure.EfCore.Data;

namespace PrancaBeauty.WebApp.Pages.Home
{
    public class AddDataModel : PageModel
    {
        public void OnGet()
        {
            new AddDataMain().Run();
        }
    }
}
