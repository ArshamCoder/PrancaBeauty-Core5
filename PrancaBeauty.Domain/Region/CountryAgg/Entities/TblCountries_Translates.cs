using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Region.CountryAgg.Entities
{
    public class TblCountries_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }

        public virtual TblCountries TblCountrie { get; set; }
        public virtual TblLanguage TblLanguage { get; set; }

    }
}
