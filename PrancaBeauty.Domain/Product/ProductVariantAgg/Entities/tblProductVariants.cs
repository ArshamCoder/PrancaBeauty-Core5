using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductVariantAgg.Entities
{
    public class tblProductVariants : IEntity
    {
        public Guid Id { get; set; }
        public string VariantType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<tblProductVariants_Translates> tblProductVariants_Translates { get; set; }
        public virtual ICollection<tblProductVariantItems> tblProductVariantItems { get; set; }
    }
}
