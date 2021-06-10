using Framework.Infrastructure;
using PrancaBeauty.Domain.User.AddressAgg.Contracts;
using PrancaBeauty.Domain.User.AddressAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Address
{
    public class AddressRepository : BaseRepository<TblAddress>, IAddressRepository
    {
        public AddressRepository(MainContext context) : base(context)
        {

        }
    }
}
