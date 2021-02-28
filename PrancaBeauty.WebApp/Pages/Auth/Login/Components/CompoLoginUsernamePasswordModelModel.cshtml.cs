﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth.Login.Components
{
    public class CompoLoginUsernamePasswordModelModel : PageModel
    {
        private readonly IUserApplication _userApplication;
        private readonly IMsgBox _msgBox;
        public CompoLoginUsernamePasswordModelModel(IUserApplication userApplication, IMsgBox msgBox)
        {
            _userApplication = userApplication;
            _msgBox = msgBox;
        }

        [BindProperty]
        public ViCompoLoginUsernamePasswordModel Input { get; set; }

        public IActionResult OnGet(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return _msgBox.ModelStateMsg(ModelState.GetErrors());


            var result = await _userApplication.LoginByUserNamePasswordAsync(Input.Email, Input.Password);

            if (result.IsSucceed)
            {

            }
            else
            {

            }

            return Page();

        }
    }
}