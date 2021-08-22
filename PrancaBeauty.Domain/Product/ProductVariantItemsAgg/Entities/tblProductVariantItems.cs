using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Domain.Product.ProductSellerAgg.Entities;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Entities
{
    public class tblProductVariantItems : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductSellerId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public double Percent { get; set; }

        public virtual tblProductVariants tblProductVariants { get; set; }
        public virtual tblProducts tblProducts { get; set; }
        public virtual tblProductSellers tblProductSellers { get; set; }
    }
}
