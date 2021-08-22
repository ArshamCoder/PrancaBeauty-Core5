using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductMediaAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductMediaAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductMedia
{
    public class ProductMediaRepository : BaseRepository<tblProductMedia>, IProductMediaRepository
    {

        public ProductMediaRepository(MainContext Context) : base(Context)
        {

        }
    }
}
