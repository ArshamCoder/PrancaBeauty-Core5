using PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Contracts;

namespace PrancaBeauty.Application.Apps.ProductPropertiesValues
{
    public class ProductPropertiesValuesApplication : IProductPropertiesValuesApplication
    {
        private readonly IProductPropertiesValuesRepository _ProductPropertiesValuesRepository;

        public ProductPropertiesValuesApplication(IProductPropertiesValuesRepository productPropertiesValuesRepository)
        {
            _ProductPropertiesValuesRepository = productPropertiesValuesRepository;
        }
    }
}
