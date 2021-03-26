using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Common.ExMothods;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataLanguage
    {
        BaseRepository<TblLanguage> _repLang;
        public AddDataLanguage()
        {
            _repLang = new BaseRepository<TblLanguage>(new MainContext());
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
                    Abbr = "fa"
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
                    Abbr = "en"
                }, default, true).Wait();
            }
        }
    }
}
