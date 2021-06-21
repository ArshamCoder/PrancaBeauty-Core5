using AutoMapper;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.User.EditProfile.Components.AccountSettings
{
    [Authorize]
    public class Compo_AccountSettingsModel : PageModel
    {
        private readonly IMsgBox _msgBox;
        private readonly ILocalizer _localizer;
        private readonly IUserApplication _userApplication;
        private readonly ISettingApplication _settingApplication;
        private readonly IMapper _mapper;
        public Compo_AccountSettingsModel(IMsgBox msgBox, IUserApplication userApplication, ILocalizer localizer, ISettingApplication settingApplication, IMapper mapper)
        {
            _msgBox = msgBox;
            _userApplication = userApplication;
            _localizer = localizer;
            _settingApplication = settingApplication;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var qData = await _userApplication.GetUserDetailsForAccountSettingsAsync(User.GetUserDetails().UserId);

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
                string SiteUrl = (await _settingApplication.GetSettingAsync(CultureInfo.CurrentCulture.Name)).SiteUrl;

                var Result = await _userApplication
                    .SaveAccountSettingUserDetailsAsync(
                        User.GetUserDetails().UserId,
                        _mapper.Map<InpSaveAccountSettingUserDetails>(Input),
                        $"{SiteUrl}/{CultureInfo.CurrentCulture.Parent.Name}/Auth/ChangeEmail?Token=[Token]");
                if (Result.IsSucceed)
                {
                    return _msgBox.SuccessMsg(_localizer[Result.Message]);
                }
                else
                {
                    return _msgBox.FaildMsg(_localizer[Result.Message]);
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
