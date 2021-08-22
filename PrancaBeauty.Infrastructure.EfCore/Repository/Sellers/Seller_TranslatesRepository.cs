using Framework.Infrastructure;
using PrancaBeauty.Domain.User.SellerAgg.Contracts;
using PrancaBeauty.Domain.User.SellerAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Sellers
{
    public class Seller_TranslatesRepository : BaseRepository<tblSeller_Translates>, ISeller_TranslatesRepository
    {
        public Seller_TranslatesRepository(MainContext Context) : base(Context)
        {

        }
    }
}
