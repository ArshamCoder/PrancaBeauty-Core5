using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using System;

namespace PrancaBeauty.Domain.User.RoleAgg.Entities
{
    public class TblRole : IdentityRole<Guid>, IEntity
    {
        public Guid? ParentId { get; set; }
        public string PageName { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
    }
}
