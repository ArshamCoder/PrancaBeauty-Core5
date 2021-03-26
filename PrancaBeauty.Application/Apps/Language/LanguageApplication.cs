using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Language;
using PrancaBeauty.Domain.Region.LanguageAgg.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Language
{
    public class LanguageApplication : ILanguageApplication
    {
        private readonly ILanguageRepository _languageRepository;
        private List<OutSiteLangCache> _siteLangCache;

        public LanguageApplication(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<string> GetCodeByAbbrAsync(string Abbr)
        {
            await LoadCacheAsync();

            return _siteLangCache
                .Where(a => a.Abbr == Abbr)
                .Select(a => a.Code)
                .SingleOrDefault();
        }

        public async Task<string> GetNativeNameByCodeAsync(string Code)
        {
            await LoadCacheAsync();

            return _siteLangCache
                .Where(a => a.Code == Code)
                .Select(a => a.NativeName)
                .SingleOrDefault();
        }

        private async Task LoadCacheAsync()
        {
            if (_siteLangCache == null)
            {
                _siteLangCache = await _languageRepository.Get
                    .Where(a => a.IsActive)
                    .Where(a => a.UseForSiteLanguage)
                    .Select(a => new OutSiteLangCache
                    {
                        Id = a.Id.ToString(),
                        Abbr = a.Abbr,
                        Code = a.Code,
                        IsRtl = a.IsRtl,
                        Name = a.Name,
                        NativeName = a.NativeName
                    })
                    .ToListAsync();
            }

        }

        public async Task<List<OutSiteLangCache>> GetAllLanguageForSiteLangAsync()
        {
            await LoadCacheAsync();

            return _siteLangCache;
        }


    }
}
