using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductTopicAgg.Entities
{
    public class tblProductTopic_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductTopicId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }

        public virtual tblProductTopic tblProductTopic { get; set; }
        public virtual TblLanguage tblLanguages { get; set; }
    }
}
