using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Domain.SettingAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataSetting
    {
        BaseRepository<TblSetting> _repSetting;
        BaseRepository<TblLanguage> _repLang;
        public AddDataSetting()
        {
            _repSetting = new BaseRepository<TblSetting>(new MainContext());
            _repLang = new BaseRepository<TblLanguage>(new MainContext());
        }

        public void Run()
        {
            if (!_repSetting.Get.Any(a => a.IsEnable == true && a.TblLanguage.Code == "fa-IR"))
            {
                _repSetting.AddAsync(new TblSetting()
                {
                    Id = new Guid().SequentialGuid(),
                    Date = DateTime.Now,
                    IsEnable = true,
                    IsInManufacture = false,
                    LangId = _repLang.Get.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
                    SiteDescription = "سایت فروشگاهی پرنسابیوتی",
                    SiteEmail = "info@prancabeauty.com",
                    SitePhoneNumber = "09147922542",
                    SiteTitle = "پرنسابیوتی",
                    SiteUrl = "https://localhost:44382"
                }, default, true).Wait();
            }
            if (!_repSetting.Get.Any(a => a.IsEnable == true && a.TblLanguage.Code == "en-US"))
            {
                _repSetting.AddAsync(new TblSetting()
                {
                    Id = new Guid().SequentialGuid(),
                    Date = DateTime.Now,
                    IsEnable = true,
                    IsInManufacture = false,
                    LangId = _repLang.Get.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
                    SiteDescription = "PrancaBeauty Shop",
                    SiteEmail = "info@prancabeauty.com",
                    SitePhoneNumber = "09147922542",
                    SiteTitle = "PrancaBeauty",
                    SiteUrl = "https://localhost:44377"
                }, default, true).Wait();
            }
        }
    }
}
