using Framework.Domain;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.User.SellerAgg.Entities
{
    public class tblSellers : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual TblUser tblUsers { get; set; }
        public virtual ICollection<tblSeller_Translates> tblSeller_Translates { get; set; }

    }
}
