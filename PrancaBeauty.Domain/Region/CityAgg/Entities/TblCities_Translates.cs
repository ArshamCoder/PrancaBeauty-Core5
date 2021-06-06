using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Region.CityAgg.Entities
{
    public class TblCities_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }

        public virtual TblCities tblCity { get; set; }
        public virtual TblLanguage tblLanguage { get; set; }
    }
}
