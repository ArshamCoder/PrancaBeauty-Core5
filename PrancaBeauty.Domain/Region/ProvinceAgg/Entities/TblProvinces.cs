using Framework.Domain;
using PrancaBeauty.Domain.Region.CityAgg.Entities;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Region.ProvinceAgg.Entities
{
    /// <summary>
    /// نام استان
    /// </summary>
    public class TblProvinces : IEntity
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual TblCountries tblCountry { get; set; }
        public virtual ICollection<TblProvinces_Translate> tblProvinces_Translate { get; set; }
        public virtual ICollection<TblCities> tblCities { get; set; }
    }
}
