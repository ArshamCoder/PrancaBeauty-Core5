using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAskAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductAskLikesAgg.Entities
{
    public class tblProductAskLikes : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductAskId { get; set; }
        public Guid UserId { get; set; }
        public bool IsLike { get; set; }
        public DateTime Date { get; set; }

        public virtual tblProductAsk tblProductAsk { get; set; }
        public virtual TblUser tblUsers { get; set; }
    }
}
