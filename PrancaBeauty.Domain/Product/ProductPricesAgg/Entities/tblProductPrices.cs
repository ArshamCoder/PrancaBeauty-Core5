using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductPricesAgg.Entities
{
    public class tblProductPrices : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public virtual tblProducts tblProducts { get; set; }
        public virtual TblUser tblUsers { get; set; }
    }
}
