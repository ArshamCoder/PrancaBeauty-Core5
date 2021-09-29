﻿using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Domain.User.AddressAgg.Entities;
using System;
using System.Collections.Generic;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;

namespace PrancaBeauty.Domain.Region.CountryAgg.Entities
{
    public class TblCountries : IEntity
    {
        public Guid Id { get; set; }
        public Guid FlagImgId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// مثلا پر میشه
        /// +98
        /// یا
        /// +1
        /// </summary>
        public string PhoneCode { get; set; }
        public bool IsActive { get; set; }

        public virtual TblFile tblFiles { get; set; }
        public virtual ICollection<TblCountries_Translates> tblCountries_Translates { get; set; }
        public virtual ICollection<TblAddress> tblAddress { get; set; }
        public virtual ICollection<TblProvinces> TblProvinces { get; set; }
        public virtual ICollection<TblLanguage> tblLanguages { get; set; }
    }
}
