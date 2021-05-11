﻿using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewModel
{
    public class VmListUsers
    {
        public string Id { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "AccessLevelName")]
        public string AccessLevelName { get; set; }

        [Display(Name = "RegDate")]
        public string Date { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [Display(Name = "IsEmailConfirmed")]
        public bool IsEmailConfirmed { get; set; }

        [Display(Name = "IsPhoneNumberConfirmed")]
        public bool IsPhoneNumberConfirmed { get; set; }
    }
}