using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataLanguage
    {
        readonly BaseRepository<TblLanguage> _repLang;
        readonly BaseRepository<TblFileServer> _FileServer;
        readonly BaseRepository<TblCountries> _Country;
        public AddDataLanguage()
        {
            _repLang = new BaseRepository<TblLanguage>(new MainContext());
            _FileServer = new BaseRepository<TblFileServer>(new MainContext());
            _Country = new BaseRepository<TblCountries>(new MainContext());
        }
        public void Run()
        {
            if (!_repLang.GetNoTraking.Any(a => a.Code == "fa-IR"))
            {
                _repLang.AddAsync(new TblLanguage()
                {
                    Id = new Guid().SequentialGuid(),
                    Code = "fa-IR",
                    IsActive = true,
                    IsRtl = true,
                    Name = "Persian_IR",
                    NativeName = "فارسی (ایران)",
                    Abbr = "fa",
                    UseForSiteLanguage = true,
                    CountryId = _Country.Get.Where(a => a.Name == "Iran").Select(a => a.Id).Single()
                }, default, true).Wait();
            }

            if (!_repLang.GetNoTraking.Any(a => a.Code == "en-US"))
            {
                _repLang.AddAsync(new TblLanguage()
                {
                    Id = new Guid().SequentialGuid(),
                    Code = "en-US",
                    IsActive = true,
                    IsRtl = false,
                    Name = "English_USA",
                    NativeName = "English (USA)",
                    Abbr = "en",
                    UseForSiteLanguage = true,
                    CountryId = _Country.Get.Where(a => a.Name == "USA").Select(a => a.Id).Single()
                }, default, true).Wait();
            }
        }
    }
}
