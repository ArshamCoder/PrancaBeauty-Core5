using Framework.Infrastructure;
using PrancaBeauty.Domain.User.SellerAgg.Contracts;
using PrancaBeauty.Domain.User.SellerAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Sellers
{
    public class SellersRepository : BaseRepository<tblSellers>, ISellersRepository
    {
        public SellersRepository(MainContext Context) : base(Context)
        {

        }
    }
}
