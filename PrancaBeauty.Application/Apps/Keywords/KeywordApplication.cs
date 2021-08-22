using PrancaBeauty.Domain.Keywords.KeywordAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Keywords
{
    public class KeywordApplication : IKeywordApplication
    {
        private readonly IKeywordRepository _KeywordRepository;
        public KeywordApplication(IKeywordRepository keywordRepository)
        {
            _KeywordRepository = keywordRepository;
        }

    }
}
