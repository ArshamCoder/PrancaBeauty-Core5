using Framework.Domain;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using System;

namespace PrancaBeauty.Domain.User.AccessLevelAgg.Entities
{


    public class TblAccessLevel_Role : IEntity
    {
        public Guid Id { get; set; }
        public Guid AccessLevelId { get; set; }
        public Guid RoleId { get; set; }


        public virtual TblAccessLevels TblAccessLevels { get; set; }
        public virtual TblRole TblRole { get; set; }

    }
}
