using Framework.Domain;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Region.CityAgg.Entities
{
    public class TblCities : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual TblProvinces TblProvince { get; set; }
        public virtual ICollection<TblCities_Translates> TblCities_Translates { get; set; }
    }
}
