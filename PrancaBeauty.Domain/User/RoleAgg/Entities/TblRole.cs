using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.User.RoleAgg.Entities
{
    public class TblRole : IdentityRole<Guid>, IEntity
    {
        public Guid? ParentId { get; set; }
        public string PageName { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }

        public virtual TblRole tblRoles_Parent { get; set; }
        public virtual ICollection<TblRole> tblRoles_Childs { get; set; }
        public virtual ICollection<TblAccessLevel_Role> TblAccessLevel_Roles { get; set; }
    }
}
