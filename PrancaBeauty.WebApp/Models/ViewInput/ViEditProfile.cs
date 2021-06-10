using System;
using System.ComponentModel.DataAnnotations;

namespace a
{
    public class ViEditProfile
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "RequiredMsg")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "StringLengthMsg")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "RequiredMsg")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "StringLengthMsg")]
        public string LastName { get; set; }

        [Display(Name = "BirthDate")]
        public DateTime? BirthDate { get; set; }
    }
}
