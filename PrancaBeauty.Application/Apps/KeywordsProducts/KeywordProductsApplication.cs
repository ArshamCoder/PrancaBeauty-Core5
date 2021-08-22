using PrancaBeauty.Domain.Keywords.Keywords_Products.Contracts;

namespace PrancaBeauty.Application.Apps.KeywordsProducts
{
    public class KeywordProductsApplication : IKeywordProductsApplication
    {
        private readonly IKeywords_ProductsRepository _IKeywords_ProductsRepository;
        public KeywordProductsApplication(IKeywords_ProductsRepository iKeywords_ProductsRepository)
        {
            _IKeywords_ProductsRepository = iKeywords_ProductsRepository;
        }
    }
}
