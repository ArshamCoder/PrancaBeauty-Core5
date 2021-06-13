using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Shared.Components
{
    public class Compo_Combo_LanguageModel : PageModel
    {
        private readonly ILanguageApplication _languageApplication;
        public Compo_Combo_LanguageModel(ILanguageApplication languageApplication)
        {
            _languageApplication = languageApplication;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<JsonResult> OnGetReadAsync()
        {
            var qData = await _languageApplication.GetAllLanguageForSiteLangAsync();
            return new JsonResult(qData);
        }

        [BindProperty(SupportsGet = true)]
        public ViCompo_Combo_Language Input { get; set; }
    }
}
