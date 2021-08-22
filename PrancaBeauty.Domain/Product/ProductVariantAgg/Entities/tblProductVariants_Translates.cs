using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductVariantAgg.Entities
{
    public class tblProductVariants_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }

        public virtual tblProductVariants tblProductVariants { get; set; }
        public virtual TblLanguage tblLanguages { get; set; }

    }
}
