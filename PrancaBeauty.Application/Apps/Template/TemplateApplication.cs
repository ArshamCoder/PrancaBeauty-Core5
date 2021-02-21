using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Contracts.Templates;
using PrancaBeauty.Domain.TemplateAgg.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Template
{
    public class TemplateApplication : ITemplateApplication
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly ISettingApplication _settingApplication;
        private List<OutTemplate> _listTemplate;

        public TemplateApplication(ITemplateRepository templateRepository, ISettingApplication settingApplication)
        {
            _templateRepository = templateRepository;
            _settingApplication = settingApplication;
            _listTemplate = new List<OutTemplate>();
        }


        public async Task<string> GetEmailConfirmationTemplateAsync(string langCode, string url)
        {
            string template = await GetTemplateAsync(langCode, "ConfirmationEmail");

            return (await SetGeneralParameters(template, langCode))
                .Replace("[Url]", url);
        }


        public async Task<string> GetTemplateAsync(string langCode, string name)
        {
            if (_listTemplate != null)
                if (_listTemplate.Any(a => a.Name == name && a.LangCode == langCode))
                    return _listTemplate.Where(a => a.Name == name && a.LangCode == langCode).Select(a => a.Template).FirstOrDefault();

            string template = await _templateRepository.GetNoTraking
                .Where(a => a.Name == name && a.Language.Code == langCode)
                .Select(a => a.Template)
                .FirstOrDefaultAsync();

            _listTemplate?.Add(new OutTemplate
            {
                Name = name,
                LangCode = langCode,
                Template = template
            });
            ;

            return template;
        }


        private async Task<string> SetGeneralParameters(string template, string langCode)
        {
            var qSetting = await _settingApplication.GetSettingAsync(langCode);

            return template.Replace("[SiteName]", qSetting.SiteTitle)
                .Replace("[SiteUrl]", qSetting.SiteUrl);
        }

        public void ClearCache()
        {
            _listTemplate = new List<OutTemplate>();
        }
    }
}
