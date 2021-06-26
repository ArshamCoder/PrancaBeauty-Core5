using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class ViCompo_ChangePassword
    {
        [Display(Name = "CurrentPassword")]
        [Required(ErrorMessage = "RequiredMsg")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "NewPassword")]
        [Required(ErrorMessage = "RequiredMsg")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "RequiredMsg")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "CompareMsg")]
        public string ConfirmPassword { get; set; }

    }
}
