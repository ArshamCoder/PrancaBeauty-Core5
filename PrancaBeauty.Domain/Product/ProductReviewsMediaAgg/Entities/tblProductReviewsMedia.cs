using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Entities
{
    public class tblProductReviewsMedia : IEntity
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid ProductReviewsId { get; set; }
        public int Sort { get; set; }


        public virtual tblProductReviews tblProductReviews { get; set; }
        public virtual TblFile tblFiles { get; set; }
    }
}
