using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Entities
{
    public class tblProductPropertiesValues : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductPropertiesId { get; set; }
        public Guid ProductId { get; set; }
        public string Value { get; set; }

        public virtual tblProductPropertis tblProductPropertis { get; set; }
        public virtual tblProducts tblProducts { get; set; }
    }
}
