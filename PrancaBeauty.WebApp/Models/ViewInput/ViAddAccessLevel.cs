using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class ViAddAccessLevel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "RequiredMsg")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "StringLengthMsg")]
        public string Name { get; set; }

        [Display(Name = "Roles")]
        public string[] Roles { get; set; }
    }
}
