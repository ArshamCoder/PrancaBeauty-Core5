using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Entities;
using PrancaBeauty.Domain.Product.ProductSellerAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities
{
    public class tblProductReviews : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ProductSellerId { get; set; } // کاربر فروشنده
        public Guid AuthorUserId { get; set; } // کاربر نویسنده دیدگاه
        public bool IsRead { get; set; }
        public bool IsConfirm { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string IpAddress { get; set; }
        public int CountStar { get; set; }
        public string Advantages { get; set; } // نقاط قوت
        public string DisAdvantages { get; set; } // نقاط ضعف
        public virtual tblProducts tblProducts { get; set; }
        public virtual tblProductSellers tblProductSellers { get; set; }
        public virtual TblUser tblUsers { get; set; }
        public virtual ICollection<tblProductReviewsLikes> tblProductReviewsLikes { get; set; }
        public virtual ICollection<tblProductReviewsMedia> tblProductReviewsMedia { get; set; }
        public virtual ICollection<tblProductReviewsAttributeValues> tblProductReviewsAttributeValues { get; set; }



    }
}
