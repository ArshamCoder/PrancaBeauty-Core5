using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using System;

namespace PrancaBeauty.Domain.User.UserAgg.Entities
{
    public class TblUser : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }
}
