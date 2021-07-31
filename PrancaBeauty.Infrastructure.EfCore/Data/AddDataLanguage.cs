using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataLanguage
    {
        BaseRepository<TblLanguage> _repLang;
        readonly BaseRepository<TblFileServer> _FileServer;
        public AddDataLanguage()
        {
            _repLang = new BaseRepository<TblLanguage>(new MainContext());
            _FileServer = new BaseRepository<TblFileServer>(new MainContext());
        }
        public void Run()
        {
            if (!_repLang.GetNoTraking.Any(a => a.Code == "fa-IR"))
            {
                _repLang.AddAsync(new TblLanguage()
                {
                    Id = new Guid().SequentialGuid(),
                    Code = "fa-IR",
                    UseForSiteLanguage = true,
                    IsActive = true,
                    IsRtl = true,
                    Name = "Persian_IR",
                    NativeName = "فارسی (ایران)",
                    Abbr = "fa",
                    TblFile = new TblFile()
                    {
                        Id = new Guid().SequentialGuid(),
                        Title = "IranFlag",
                        Date = DateTime.Now,
                        FileName = "IranFlag.png",
                        FileServerId = _FileServer.GetNoTraking.Where(a => a.Name == "Public").Select(a => a.Id).Single(),
                        MimeType = "image/png",
                        Path = "/Img/flags/",
                        SizeOnDisk = 0
                    }
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
                    UseForSiteLanguage = true,
                    Name = "English_USA",
                    NativeName = "English (USA)",
                    Abbr = "en",
                    TblFile = new TblFile()
                    {
                        Id = new Guid().SequentialGuid(),
                        Title = "UsFlag",
                        Date = DateTime.Now,
                        FileName = "UsFlag.png",
                        FileServerId = _FileServer.GetNoTraking.Where(a => a.Name == "Public").Select(a => a.Id).Single(),
                        MimeType = "image/png",
                        Path = "/Img/flags/",
                        SizeOnDisk = 0
                    }
                }, default, true).Wait();
            }
        }
    }
}
