using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Entities
{
    public class tblProductReviewsAttributeValues : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductReviewId { get; set; }
        public Guid ProductReviewAttributeId { get; set; }
        public string Value { get; set; }

        public virtual tblProductReviews tblProductReviews { get; set; }
        public virtual tblProductReviewsAttribute tblProductReviewsAttribute { get; set; }
    }
}
