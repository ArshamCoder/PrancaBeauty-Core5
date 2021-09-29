using System;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Language;
using PrancaBeauty.Domain.Region.LanguageAgg.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;

namespace PrancaBeauty.Application.Apps.Language
{
    public class LanguageApplication : ILanguageApplication
    {
        private readonly ILanguageRepository _languageRepository;
        private List<OutSiteLangCache> _siteLangCache;
        private readonly ILogger _Logger;

        public LanguageApplication(ILanguageRepository languageRepository, ILogger logger)
        {
            _languageRepository = languageRepository;
            _Logger = logger;
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
            try
            {
                if (_siteLangCache == null)
                {
                    _siteLangCache = await _languageRepository.Get
                        .Where(a => a.IsActive)
                        .Where(a => a.UseForSiteLanguage)
                        .Select(a => new OutSiteLangCache
                        {
                            Id = a.Id.ToString(),
                            CountryId = a.CountryId.ToString(),
                            Abbr = a.Abbr,
                            Code = a.Code,
                            IsRtl = a.IsRtl,
                            Name = a.Name,
                            NativeName = a.NativeName,
                            FlagUrl = a.tblCountries.tblFiles.tblFilePaths.tblFileServer.HttpDomin +
                                      a.tblCountries.tblFiles.tblFilePaths.tblFileServer.HttpPath +
                                      a.tblCountries.tblFiles.tblFilePaths.Path +
                                      a.tblCountries.tblFiles.FileName
                        })
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
            }

        }

        public async Task<List<OutSiteLangCache>> GetAllLanguageForSiteLangAsync()
        {
            await LoadCacheAsync();

            return _siteLangCache;
        }


        public async Task<string> GetFlagUrlByCodeAsync(string code)
        {
            await LoadCacheAsync();

            return _siteLangCache
                .Where(a => a.Code == code)
                .Select(a => a.FlagUrl)
                .SingleOrDefault();
        }

        public async Task<string> GetDirectionByCodeAsync(string code)
        {
            //راست به چپ یا چپ به راست
            // قالب را مشخص می کند
            await LoadCacheAsync();

            return _siteLangCache
                .Where(a => a.Code == code)
                .Select(a => a.IsRtl ? "rtl" : "ltr")
                .SingleOrDefault();
        }

        public async Task<string> GetAbbrByCodeAsync(string code)
        {
            await LoadCacheAsync();

            return _siteLangCache
                .Where(a => a.Code == code)
                .Select(a => a.Abbr)
                .SingleOrDefault();
        }

        public async Task<bool> IsValidAbbrForSiteLangAsync(string abbr)
        {
            await LoadCacheAsync();

            return _siteLangCache
                .Any(a => a.Abbr == abbr);
        }

        public async Task<string> GetLangIdByLangCodeAsync(string langCode)
        {
            await LoadCacheAsync();

            return _siteLangCache
                .Where(a => a.Code == langCode)
                .Select(a => a.Id)
                .SingleOrDefault();
        }

        public async Task<OutSiteLangCache> GetLangDetailsByIdAsync(string langId)
        {
            return (await GetAllLanguageForSiteLangAsync()).SingleOrDefault(a => a.Id == langId);
        }

    }
}
