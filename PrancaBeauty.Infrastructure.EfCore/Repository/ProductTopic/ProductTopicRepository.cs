using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductTopic
{
    public class ProductTopicRepository : BaseRepository<tblProductTopic>, IProductTopicRepository
    {
        public ProductTopicRepository(MainContext Context) : base(Context)
        {

        }
    }
}
