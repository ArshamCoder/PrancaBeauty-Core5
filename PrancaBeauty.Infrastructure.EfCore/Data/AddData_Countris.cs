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
using PrancaBeauty.Domain.FileServer.FilePathAgg.Entities;
using PrancaBeauty.Domain.FileServer.FileTypeAgg.Entities;

namespace PrancaBeauty.Infrastructure.EFCore.Data
{
    public class AddData_Countris
    {
        BaseRepository<TblCountries> _Countries;
        BaseRepository<TblLanguage> _Language;
        BaseRepository<tblFileTypes> _FileTypes;
        BaseRepository<tblFilePaths> _FilePaths;
        public AddData_Countris()
        {
            _Countries = new BaseRepository<TblCountries>(new MainContext());
            _Language = new BaseRepository<TblLanguage>(new MainContext());
            _FileTypes = new BaseRepository<tblFileTypes>(new MainContext());
            _FilePaths = new BaseRepository<tblFilePaths>(new MainContext());
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
                    PhoneCode = "098",
                    tblFiles = new TblFile()
                    {
                        Id = new Guid().SequentialGuid(),
                        FilePathId = _FilePaths.Get.Where(a => a.Path == "/Img/flags/").Where(a => a.tblFileServer.Name == "Public").Select(a => a.Id).Single(),
                        Title = "IranCountryFlag",
                        Date = DateTime.Now,
                        FileName = "IranCountryFlag.png",
                        FileTypeId = _FileTypes.Get.Where(a => a.MimeType == "image/png").Select(a => a.Id).Single(),
                        SizeOnDisk = 0
                    }
                }, default).Wait();
            }

            if (!_Countries.Get.Any(a => a.Name == "USA"))
            {
                _Countries.AddAsync(new TblCountries()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "USA",
                    IsActive = true,
                    PhoneCode = "001",
                    tblFiles = new TblFile()
                    {
                        Id = new Guid().SequentialGuid(),
                        FilePathId = _FilePaths.Get.Where(a => a.Path == "/Img/flags/").Where(a => a.tblFileServer.Name == "Public").Select(a => a.Id).Single(),
                        Title = "USACountryFlag",
                        Date = DateTime.Now,
                        FileName = "USACountryFlag.png",
                        FileTypeId = _FileTypes.Get.Where(a => a.MimeType == "image/png").Select(a => a.Id).Single(),
                        SizeOnDisk = 0
                    }
                }, default).Wait();
            }
        }
    }
}
