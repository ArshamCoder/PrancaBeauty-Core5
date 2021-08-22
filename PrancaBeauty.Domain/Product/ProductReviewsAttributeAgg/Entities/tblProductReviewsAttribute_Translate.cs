using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities
{
    public class tblProductReviewsAttribute_Translate : IEntity
    {
        public Guid Id { get; set; }
        public Guid LangId { get; set; }
        public Guid ProductReviewsAttributeId { get; set; }
        public string Title { get; set; }

        public virtual tblProductReviewsAttribute tblProductReviewsAttribute { get; set; }
        public virtual TblLanguage tblLanguages { get; set; }
    }
}
