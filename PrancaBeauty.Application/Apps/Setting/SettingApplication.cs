using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Setting;
using PrancaBeauty.Domain.Setting.SettingAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Setting
{
    public class SettingApplication : ISettingApplication
    {
        private readonly ISettingRepository _settingRepository;
        private IList<OutSetting> _listOutSetting;
        private readonly ILogger _Logger;

        public SettingApplication(ISettingRepository settingRepository, ILogger logger)
        {
            _settingRepository = settingRepository;
            _Logger = logger;
            _listOutSetting = new List<OutSetting>();
        }

        public async Task<OutSetting> GetSettingAsync(string langCode)
        {
            if (_listOutSetting != null)
                if (_listOutSetting.Any(a => a.LangCode == langCode))
                    return _listOutSetting.FirstOrDefault(a => a.LangCode == langCode);

            var qSetting = await LoadSettingAsync(langCode);
            if (qSetting == null)
                throw new Exception("");

            _listOutSetting.Add(qSetting);
            return qSetting;
        }

        private async Task<OutSetting> LoadSettingAsync(string langCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(langCode))
                    throw new ArgumentNullException("LangCode can`t be null.");

                var qData = await _settingRepository.GetNoTraking
                    .Where(a => a.TblLanguage.Code == langCode && a.IsEnable)
                    .Select(a => new OutSetting
                    {
                        IsInManufacture = a.IsInManufacture,
                        LangCode = a.TblLanguage.Code,
                        SiteDescription = a.SiteDescription,
                        SiteEmail = a.SiteEmail,
                        SitePhoneNumber = a.SitePhoneNumber,
                        SiteTitle = a.SiteTitle,
                        SiteUrl = a.SiteUrl
                    })
                    .FirstOrDefaultAsync();

                if (qData == null)
                    throw new Exception($"qData is null, LangCode: [{langCode}]");



                return qData;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return null;
            }
        }


        public void ClearCache()
        {
            _listOutSetting = new List<OutSetting>();
        }

    }
}
