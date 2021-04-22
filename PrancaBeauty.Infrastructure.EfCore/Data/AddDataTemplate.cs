using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Domain.TemplateAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataTemplate
    {
        BaseRepository<TblTemplate> _repTemplate;
        BaseRepository<TblLanguage> _repLang;
        public AddDataTemplate()
        {
            _repTemplate = new BaseRepository<TblTemplate>(new MainContext());
            _repLang = new BaseRepository<TblLanguage>(new MainContext());
        }

        public void Run()
        {

            // ConfirmationEmail  fa-IR
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "fa-IR" && a.Name == "ConfirmationEmail"))
            {
                _repTemplate.AddAsync(new TblTemplate()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
                    Name = "ConfirmationEmail",
                    Template = "<a href='[Url]'>کلیک</a>"
                }, default, true).Wait();
            }

            // ConfirmationEmail  en-US
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "en-US" && a.Name == "ConfirmationEmail"))
            {
                _repTemplate.AddAsync(new TblTemplate()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
                    Name = "ConfirmationEmail",
                    Template = "<a href='[Url]'>Click</a>"
                }, default, true).Wait();
            }





            // EmailLogin  fa-IR
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "fa-IR" && a.Name == "EmailLogin"))
            {
                _repTemplate.AddAsync(new TblTemplate()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "fa-IR").Select(a => a.Id).Single(),
                    Name = "EmailLogin",
                    Template = "<a href='[Url]'>ورود به سایت</a>"
                }, default, true).Wait();
            }

            // EmailLogin  en-US
            if (!_repTemplate.GetNoTraking.Any(a => a.Language.Code == "en-US" && a.Name == "EmailLogin"))
            {
                _repTemplate.AddAsync(new TblTemplate()
                {
                    Id = new Guid().SequentialGuid(),
                    LangId = _repLang.GetNoTraking.Where(a => a.Code == "en-US").Select(a => a.Id).Single(),
                    Name = "EmailLogin",
                    Template = "<a href='[Url]'>Click To Login</a>"
                }, default, true).Wait();
            }





        }
    }
}
