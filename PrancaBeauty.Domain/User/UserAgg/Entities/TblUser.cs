using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using System;

namespace PrancaBeauty.Domain.User.UserAgg.Entities
{
    public class TblUser : IdentityUser<Guid>, IEntity
    {
        public Guid AccessLevelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }


        public virtual TblAccessLevels TblAccessLevels { get; set; }
    }
}
