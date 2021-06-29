using PrancaBeauty.Application.Contracts.Language;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Language
{
    public interface ILanguageApplication
    {
        Task<string> GetCodeByAbbrAsync(string Abbr);
        Task<string> GetNativeNameByCodeAsync(string Code);
        Task<List<OutSiteLangCache>> GetAllLanguageForSiteLangAsync();
        Task<string> GetFlagUrlByCodeAsync(string code);
        Task<string> GetDirectionByCodeAsync(string code);
        Task<string> GetAbbrByCodeAsync(string code);
        Task<bool> IsValidAbbrForSiteLangAsync(string abbr);
        Task<string> GetLangIdByLangCodeAsync(string langCode);
        Task<OutSiteLangCache> GetLangDetailsByIdAsync(string langId);
    }
}
