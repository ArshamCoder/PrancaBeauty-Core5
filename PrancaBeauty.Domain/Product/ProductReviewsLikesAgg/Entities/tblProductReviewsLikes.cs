using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Entities
{
    public class tblProductReviewsLikes : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductReviewId { get; set; }
        public Guid UserId { get; set; }
        public bool IsLike { get; set; }
        public DateTime Date { get; set; }

        public virtual tblProductReviews tblProductReviews { get; set; }
        public virtual TblUser tblUsers { get; set; }
    }
}
