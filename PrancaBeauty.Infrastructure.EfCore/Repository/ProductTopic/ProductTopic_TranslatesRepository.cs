using Framework.Infrastructure;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.ProductTopic
{
    public class ProductTopic_TranslatesRepository : BaseRepository<tblProductTopic_Translates>, IProductTopic_TranslatesRepository
    {
        public ProductTopic_TranslatesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
