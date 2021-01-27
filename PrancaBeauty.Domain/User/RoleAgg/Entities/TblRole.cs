using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using System;

namespace PrancaBeauty.Domain.User.RoleAgg.Entities
{
    public class TblRole : IdentityRole<Guid>, IEntity
    {

    }
}
