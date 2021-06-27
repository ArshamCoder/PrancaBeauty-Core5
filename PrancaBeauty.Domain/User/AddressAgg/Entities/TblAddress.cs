using Framework.Domain;
using PrancaBeauty.Domain.Region.CityAgg.Entities;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;

namespace PrancaBeauty.Domain.User.AddressAgg.Entities
{
    public class TblAddress : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProviceId { get; set; }
        public Guid CityId { get; set; }
        public string District { get; set; } // محله
        public string Address { get; set; }
        public string Plaque { get; set; } // پلاک
        public string Unit { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }


        public virtual TblUser TblUser { get; set; }
        public virtual TblCountries TblCountries { get; set; }
        public virtual TblProvinces tblProvinces { get; set; }
        public virtual TblCities tblCities { get; set; }
    }
}
