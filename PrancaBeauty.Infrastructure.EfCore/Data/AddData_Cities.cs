using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.CityAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EFCore.Data
{
    public class AddData_Cities
    {
        BaseRepository<TblCities> _Cities;
        BaseRepository<TblProvinces> _Province;
        BaseRepository<TblLanguage> _Language;

        public AddData_Cities()
        {
            _Cities = new BaseRepository<TblCities>(new MainContext());
            _Province = new BaseRepository<TblProvinces>(new MainContext());
            _Language = new BaseRepository<TblLanguage>(new MainContext());
        }

        public void Run()
        {
            if (!_Cities.Get.Any(a => a.Name == "Tehran"))
            {
                _Cities.AddAsync(new TblCities()
                {
                    Id = new Guid().SequentialGuid(),
                    ProvinceId = _Province.Get.Where(a => a.Name == "Tehran").Select(a => a.Id).Single(),
                    Name = "Tehran",
                    IsActive = true,
                    TblCities_Translates = new List<TblCities_Translates> {
                        new TblCities_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="تهران"
                        },
                        new TblCities_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Tehran"
                        }
                    }
                }, default).Wait();
            }

            if (!_Cities.Get.Any(a => a.Name == "Shiraz"))
            {
                _Cities.AddAsync(new TblCities()
                {
                    Id = new Guid().SequentialGuid(),
                    ProvinceId = _Province.Get.Where(a => a.Name == "Fars").Select(a => a.Id).Single(),
                    Name = "Shiraz",
                    IsActive = true,
                    TblCities_Translates = new List<TblCities_Translates> {
                        new TblCities_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="شیراز"
                        },
                        new TblCities_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Shiraz"
                        }
                    }
                }, default).Wait();
            }

            if (!_Cities.Get.Any(a => a.Name == "Esfahan"))
            {
                _Cities.AddAsync(new TblCities()
                {
                    Id = new Guid().SequentialGuid(),
                    ProvinceId = _Province.Get.Where(a => a.Name == "Esfahan").Select(a => a.Id).Single(),
                    Name = "Esfahan",
                    IsActive = true,
                    TblCities_Translates = new List<TblCities_Translates> {
                        new TblCities_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="fa-IR").Select(a=>a.Id).Single(),
                            Title="اصفهان"
                        },
                        new TblCities_Translates{
                            Id= new Guid().SequentialGuid(),
                            LangId= _Language.Get.Where(a=>a.Code=="en-US").Select(a=>a.Id).Single(),
                            Title="Esfahan"
                        }
                    }
                }, default).Wait();
            }
        }
    }
}
