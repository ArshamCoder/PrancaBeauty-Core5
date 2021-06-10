using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EFCore.Data
{
    public class AddData_Province
    {
        BaseRepository<TblCountries> _Countries;
        BaseRepository<TblProvinces> _Province;
        BaseRepository<TblLanguage> _Language;

        public AddData_Province()
        {
            _Countries = new BaseRepository<TblCountries>(new MainContext());
            _Province = new BaseRepository<TblProvinces>(new MainContext());
            _Language = new BaseRepository<TblLanguage>(new MainContext());
        }

        public void Run()
        {
            if (!_Province.Get.Any(a => a.Name == "Tehran"))
            {
                _Province.AddAsync(new TblProvinces()
                {
                    Id = new Guid().SequentialGuid(),
                    CountryId = _Countries.Get.Where(a => a.Name == "Iran").Select(a => a.Id).Single(),
                    Name = "Tehran",
                    IsActive = true,
                    tblProvinces_Translate = new List<TblProvinces_Translate> {
                        new TblProvinces_Translate{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="تهران"
                        },
                        new TblProvinces_Translate{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Tehran"
                        }
                    }
                }, default).Wait();
            }

            if (!_Province.Get.Any(a => a.Name == "Esfahan"))
            {
                _Province.AddAsync(new TblProvinces()
                {
                    Id = new Guid().SequentialGuid(),
                    CountryId = _Countries.Get.Where(a => a.Name == "Iran").Select(a => a.Id).Single(),
                    Name = "Esfahan",
                    IsActive = true,
                    tblProvinces_Translate = new List<TblProvinces_Translate> {
                        new TblProvinces_Translate{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="اصفهان"
                        },
                        new TblProvinces_Translate{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Esfahan"
                        }
                    }
                }, default).Wait();
            }

            if (!_Province.Get.Any(a => a.Name == "Fars"))
            {
                _Province.AddAsync(new TblProvinces()
                {
                    Id = new Guid().SequentialGuid(),
                    CountryId = _Countries.Get.Where(a => a.Name == "Iran").Select(a => a.Id).Single(),
                    Name = "Fars",
                    IsActive = true,
                    tblProvinces_Translate = new List<TblProvinces_Translate> {
                        new TblProvinces_Translate{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="فارس"
                        },
                        new TblProvinces_Translate{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Fars"
                        }
                    }
                }, default).Wait();
            }
        }
    }
}
