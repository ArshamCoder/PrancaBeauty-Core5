using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class ViCompoLoginUsernamePasswordModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "RequiredMsg")]
        [EmailAddress(ErrorMessage = "EmailAddressMsg")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "RequiredMsg")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RemmeberMe")]
        public bool RemmeberMe { get; set; }
    }
}
