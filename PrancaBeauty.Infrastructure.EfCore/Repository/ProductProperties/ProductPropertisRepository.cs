using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductProperties
{
    public class ProductPropertisRepository : BaseRepository<tblProductPropertis>, IProductPropertisRepository
    {
        public ProductPropertisRepository(MainContext Context) : base(Context)
        {

        }
    }
}
