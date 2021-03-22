using PrancaBeauty.Domain.Region.LanguageAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Language
{
    public class LanguageApplication : ILanguageApplication
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageApplication(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }




    }
}
