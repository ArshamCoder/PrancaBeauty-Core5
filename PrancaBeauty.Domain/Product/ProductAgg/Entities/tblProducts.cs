using Framework.Domain;
using PrancaBeauty.Domain.Category.CategoriyAgg.Entities;
using PrancaBeauty.Domain.Keywords.Keywords_Products.Entities;
using PrancaBeauty.Domain.Product.ProductAskAgg.Entities;
using PrancaBeauty.Domain.Product.ProductMediaAgg.Entities;
using PrancaBeauty.Domain.Product.ProductPricesAgg.Entities;
using PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Entities;
using PrancaBeauty.Domain.Product.ProductSellerAgg.Entities;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductAgg.Entities
{
    public class tblProducts : IEntity
    {
        public Guid Id { get; set; }
        public Guid AuthorUserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } // Uniqe Name
        public string Title { get; set; }
        public string Descreption { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDraft { get; set; }
        public bool IsDelete { get; set; }

        public virtual TblUser tblAuthorUser { get; set; }
        public virtual TblCategoris tblCategory { get; set; }
        public virtual ICollection<tblKeywords_Products> tblKeywords_Products { get; set; }
        public virtual ICollection<tblProductPrices> tblProductPrices { get; set; }
        public virtual ICollection<tblProductMedia> tblProductMedia { get; set; }
        public virtual ICollection<tblProductReviews> tblProductReviews { get; set; }
        public virtual ICollection<tblProductAsk> tblProductAsk { get; set; }
        public virtual ICollection<tblProductPropertiesValues> tblProductPropertiesValues { get; set; }
        public virtual ICollection<tblProductVariantItems> tblProductVariantItems { get; set; }
        public virtual ICollection<tblProductSellers> tblProductSellers { get; set; }


    }
}
