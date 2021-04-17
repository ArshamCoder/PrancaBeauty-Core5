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

        /// <summary>
        /// جوین به خودت جدول
        /// برای گروه زیر گروه
        /// </summary>
        public virtual TblRole TblRoleParent { get; set; }
        public virtual ICollection<TblRole> TblRoleChild { get; set; }
        public virtual ICollection<TblAccessLevel_Role> TblAccessLevel_Roles { get; set; }
    }
}
