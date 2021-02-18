using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.TemplateAgg.Entities
{
    public class TblTemplate : IEntity
    {
        public Guid Id { get; set; }
        public Guid LangId { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }

        public virtual TblLanguage Language { get; set; }
    }
}
