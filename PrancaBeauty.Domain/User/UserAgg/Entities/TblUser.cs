﻿using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.User.UserAgg.Entities
{
    public class TblUser : IdentityUser<Guid>, IEntity
    {
        public Guid AccessLevelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string PasswordPhoneNumber { get; set; }
        public DateTime? LastTrySentSms { get; set; }
        public bool IsActive { get; set; }
        public virtual TblAccessLevels TblAccessLevels { get; set; }

        public virtual ICollection<TblFile> TblFiles { get; set; }
    }
}
