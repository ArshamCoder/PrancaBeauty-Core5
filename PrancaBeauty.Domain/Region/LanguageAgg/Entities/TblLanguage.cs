using Framework.Domain;
using PrancaBeauty.Domain.Categories.Entities;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Region.CityAgg.Entities;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Domain.SettingAgg.Entities;
using PrancaBeauty.Domain.TemplateAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Region.LanguageAgg.Entities
{
    public class TblLanguage : IEntity
    {
        public Guid Id { get; set; }
        public Guid FlagImgId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string NativeName { get; set; }

        /// <summary>
        /// مخفف زبان هست مثلا فارسی میشه
        /// fa
        /// یا انگلیسی میشه
        /// en
        /// </summary>

        public string Abbr { get; set; }
        public bool IsRtl { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// یعنی برای این زبان ریسورس قرار داده شده است یا خیر
        /// </summary>

        public bool UseForSiteLanguage { get; set; }

        public virtual ICollection<TblTemplate> TblTemplates { get; set; }
        public virtual ICollection<TblSetting> TblSettings { get; set; }

        public virtual ICollection<TblCountries_Translates> tblCountries_Translates { get; set; }
        public virtual ICollection<TblProvinces_Translate> tblProvinces_Translate { get; set; }
        public virtual ICollection<TblCities_Translates> tblCities_Translates { get; set; }
        public virtual ICollection<TblUser> tblUsers { get; set; }
        public virtual ICollection<TblCategory_Translates> tblCategory_Translates { get; set; }

        public virtual TblFile TblFile { get; set; }
    }
}
