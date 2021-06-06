using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Region.ProvinceAgg.Entities
{
    public class TblProvinces_Translate : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }

        public virtual TblProvinces TblProvinces { get; set; }
        public virtual TblLanguage TblLanguage { get; set; }
    }
}
