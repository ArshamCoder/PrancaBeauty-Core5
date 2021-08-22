using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductProperties
{
    public class ProductPropertis_TranslatesRepository : BaseRepository<tblProductPropertis_Translates>, IProductPropertis_TranslatesRepository
    {
        public ProductPropertis_TranslatesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
