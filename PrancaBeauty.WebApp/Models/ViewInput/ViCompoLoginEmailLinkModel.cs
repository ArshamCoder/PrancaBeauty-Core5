using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class ViCompoLoginEmailLinkModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "RequiredMsg")]
        [EmailAddress(ErrorMessage = "EmailAddressMsg")]
        public string Email { get; set; }

        [Display(Name = "RemmeberMe")]
        public bool RemmeberMe { get; set; }
    }
}
