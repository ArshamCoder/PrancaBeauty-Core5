using Framework.Domain;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.User.AccessLevelAgg.Entities
{
    public class TblAccessLevels : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
