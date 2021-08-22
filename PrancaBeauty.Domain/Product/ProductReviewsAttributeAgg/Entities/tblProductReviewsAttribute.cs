using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Entities;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities
{
    public class tblProductReviewsAttribute : IEntity
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }
        public string Name { get; set; }

        public virtual tblProductTopic tblProductTopic { get; set; }
        public virtual ICollection<tblProductReviewsAttribute_Translate> tblProductReviewsAttribute_Translate { get; set; }
        public virtual ICollection<tblProductReviewsAttributeValues> tblProductReviewsAttributeValues { get; set; }

    }
}
