using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Domain.User.AddressAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Region.CountryAgg.Entities
{
    public class TblCountries : IEntity
    {
        public Guid Id { get; set; }
        public Guid FlagImgId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual TblFile tblFiles { get; set; }
        public virtual ICollection<TblCountries_Translates> tblCountries_Translates { get; set; }
        public virtual ICollection<TblAddress> tblAddress { get; set; }
        public virtual ICollection<TblProvinces> TblProvinces { get; set; }
    }
}
