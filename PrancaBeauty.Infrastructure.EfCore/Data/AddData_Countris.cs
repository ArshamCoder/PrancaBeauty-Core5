using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EFCore.Data
{
    public class AddData_Countris
    {
        BaseRepository<TblCountries> _Countries;
        BaseRepository<TblFileServer> _FileServer;
        BaseRepository<TblLanguage> _Language;
        public AddData_Countris()
        {
            _Countries = new BaseRepository<TblCountries>(new MainContext());
            _FileServer = new BaseRepository<TblFileServer>(new MainContext());
            _Language = new BaseRepository<TblLanguage>(new MainContext());
        }

        public void Run()
        {
            if (!_Countries.Get.Any(a => a.Name == "Iran"))
            {
                _Countries.AddAsync(new TblCountries()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "Iran",
                    IsActive = true,
                    tblFiles = new TblFile()
                    {
                        Id = new Guid().SequentialGuid(),
                        Title = "IranCountryFlag",
                        Date = DateTime.Now,
                        FileName = "IranCountryFlag.png",
                        FileServerId = _FileServer.GetNoTraking.Where(a => a.Name == "Public").Select(a => a.Id).Single(),
                        MimeType = "image/png",
                        Path = "/flags/",
                        SizeOnDisk = 0
                    },
                    tblCountries_Translates = new List<TblCountries_Translates> {
                        new TblCountries_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="ایران"
                        },
                        new TblCountries_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Iran"
                        }
                    }
                }, default).Wait();
            }
        }
    }
}
