using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities
{
    public class tblProductPropertis_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }

        public virtual tblProductPropertis tblProductPropertis { get; set; }
        public virtual TblLanguage tblLanguages { get; set; }

    }
}
