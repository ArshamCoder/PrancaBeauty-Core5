using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.Application.Services.Email;
using PrancaBeauty.WebApp.Models.ViewInput;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Auth
{
    public class RegisterModel : PageModel
    {

        private readonly IUserApplication _userApplication;
        private readonly IEmailSender _emailSender;

        public RegisterModel(IUserApplication userApplication, IEmailSender emailSender)
        {
            _userApplication = userApplication;
            _emailSender = emailSender;
        }


        //  [BindProperty(SupportsGet = true)] // Get Data In Post And Get Method
        [BindProperty] // Get Data In Post Method
        public ViRegisterModel Input { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _userApplication.AddUserAsync(new InpAddUser()
            {
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Password = Input.Password
            });
            if (result.IsSucceed)
            {
                // ارسال ایمیل تایید
                await _emailSender.SendAsync("", "", "");
                return Page();
            }
            else
            {
                foreach (var item in result.Message.Split(", "))
                {
                    ModelState.AddModelError("", item);
                }

                return Page();
            }

            return Page();
        }
    }
}
