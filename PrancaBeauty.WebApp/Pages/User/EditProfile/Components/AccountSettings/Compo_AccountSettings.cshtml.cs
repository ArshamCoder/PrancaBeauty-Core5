using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Localization;
using PrancaBeauty.WebApp.Models.ViewInput;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.User.EditProfile.Components.AccountSettings
{
    [Authorize]
    public class Compo_AccountSettingsModel : PageModel
    {
        private readonly IMsgBox _MsgBox;
        private readonly ILocalizer _Localizer;
        private readonly IUserApplication _UserApplication;
        private readonly ISettingApplication _SettingApplication;
        private readonly IMapper _Mapper;
        public Compo_AccountSettingsModel(IMsgBox msgBox, IUserApplication userApplication, ILocalizer localizer, ISettingApplication settingApplication, IMapper mapper)
        {
            _MsgBox = msgBox;
            _UserApplication = userApplication;
            _Localizer = localizer;
            _SettingApplication = settingApplication;
            _Mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var qData = await _UserApplication.GetUserDetailsForAccountSettingsAsync(User.GetUserDetails().UserId);

            if (qData == null)
                throw new Exception();

            Input = new ViCompo_AccountSettings()
            {
                LangId = qData.LangId,
                Email = qData.Email,
                FirstName = qData.FirstName,
                LastName = qData.LastName,
                PhoneNumber = qData.PhoneNumber,
                PhoneNumberConfirmed = qData.PhoneNumberConfirmed,
                BirthDate = qData.BirthDate.HasValue ? qData.BirthDate.Value.ToString("yyyy/MM/dd") : DateTime.Now.ToString("yyyy/MM/dd")
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string SiteUrl = (await _SettingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;

                var Result = await _UserApplication
                    .SaveAccountSettingUserDetailsAsync(
                        User.GetUserDetails().UserId,
                        _Mapper.Map<InpSaveAccountSettingUserDetails>(Input),
                        $"{SiteUrl}/{CultureInfo.CurrentCulture.Parent.Name}/Auth/ChangeEmail?Token=[Token]");
                if (Result.IsSucceed)
                {
                    return _MsgBox.SuccessMsg(_Localizer[Result.Message]);
                }
                else
                {
                    return _MsgBox.FaildMsg(_Localizer[Result.Message]);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [BindProperty]
        public ViCompo_AccountSettings Input { get; set; }
    }
}
