using PrancaBeauty.Domain.User.AddressAgg.Contracts;

namespace PrancaBeauty.Application.Apps.Address
{
    public class AddressApplication : IAddressApplication
    {
        private readonly IAddressRepository _AddressRepository;

        public AddressApplication(IAddressRepository addressRepository)
        {
            _AddressRepository = addressRepository;
        }

    }
}
