using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductSellerAgg.Entities
{
    public class tblProductSellers : IEntity
    {
        public Guid Id { get; set; }
        public Guid SellerUserId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public string Guarantee { get; set; } // گارانتی
        public string SendFrom { get; set; } // ارسال از
        public DateTime Date { get; set; }
        public bool IsConfirm { get; set; }
        public virtual tblProducts tblProducts { get; set; }
        public virtual TblUser tblUsers { get; set; }
        public virtual ICollection<tblProductReviews> tblProductReviews { get; set; }
        public virtual ICollection<tblProductVariantItems> tblProductVariantItems { get; set; }
    }
}
