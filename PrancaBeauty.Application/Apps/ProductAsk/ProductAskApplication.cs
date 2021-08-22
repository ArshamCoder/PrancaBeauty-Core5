using PrancaBeauty.Domain.Product.ProductAskAgg.Contarcts;

namespace PrancaBeauty.Application.Apps.ProductAsk
{
    public class ProductAskApplication : IProductAskApplication
    {
        private readonly IProductAskRepository _ProductAskRepository;

        public ProductAskApplication(IProductAskRepository productAskRepository)
        {
            _ProductAskRepository = productAskRepository;
        }
    }
}
