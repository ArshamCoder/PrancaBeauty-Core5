using PrancaBeauty.Domain.Product.ProductTopicAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductTopic
{
    public class ProductTopicApplication : IProductTopicApplication
    {
        private readonly IProductTopicRepository _ProductTopicRepository;

        public ProductTopicApplication(IProductTopicRepository productTopicRepository)
        {
            _ProductTopicRepository = productTopicRepository;
        }
    }
}
