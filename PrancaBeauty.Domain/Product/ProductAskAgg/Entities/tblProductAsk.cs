using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using PrancaBeauty.Domain.Product.ProductAskLikesAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductAskAgg.Entities
{
    public class tblProductAsk : IEntity
    {
        public Guid Id { get; set; }
        public Guid? AskId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirm { get; set; }


        public virtual tblProducts tblProducts { get; set; }
        public virtual TblUser tblUsers { get; set; }
        public virtual tblProductAsk tblProductAsk_Parent { get; set; }
        public virtual ICollection<tblProductAsk> tblProductAsk_Childs { get; set; }
        public virtual ICollection<tblProductAskLikes> tblProductAskLikes { get; set; }
    }
}
