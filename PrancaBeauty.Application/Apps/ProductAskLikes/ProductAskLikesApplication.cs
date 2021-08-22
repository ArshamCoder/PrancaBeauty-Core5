using PrancaBeauty.Domain.Product.ProductAskLikesAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductAskLikes
{
    public class ProductAskLikesApplication : IProductAskLikesApplication
    {
        private readonly IProductAskLikesRepository _ProductAskLikesRepository;

        public ProductAskLikesApplication(IProductAskLikesRepository productAskLikesRepository)
        {
            _ProductAskLikesRepository = productAskLikesRepository;
        }
    }

}
