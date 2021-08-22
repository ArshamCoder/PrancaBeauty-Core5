using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductPropertiesValues
{
    public class ProductPropertiesValuesRepository : BaseRepository<tblProductPropertiesValues>, IProductPropertiesValuesRepository
    {
        public ProductPropertiesValuesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
