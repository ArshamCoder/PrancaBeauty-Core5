using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class ViCompoLoginUsernamePasswordModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "RequiredMsg")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "RequiredMsg")]
        public string Password { get; set; }

        [Display(Name = "RemmeberMe")]
        public bool RemmeberMe { get; set; }
    }
}
