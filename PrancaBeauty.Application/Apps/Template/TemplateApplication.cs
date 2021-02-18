using Microsoft.EntityFrameworkCore;
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
        private readonly List<OutTemplate> _listTemplate;

        public TemplateApplication(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            _listTemplate = new List<OutTemplate>();
        }


        public async Task<string> GetEmailConfirmationTemplateAsync(string langCode, string url)
        {
            string template = await GetTemplateAsync(langCode, "");

            return SetGeneralParameters(template)
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


        private string SetGeneralParameters(string template)
        {
            return template.Replace("[SiteName]", "PrancaBeauty")
                .Replace("[SiteUrl]", "https://PrancaBeauty.com");
        }
    }
}
