using Framework.Domain;
using PrancaBeauty.Domain.SettingAgg.Entities;
using PrancaBeauty.Domain.TemplateAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Region.LanguageAgg.Entities
{
    public class TblLanguage : IEntity
    {
        public Guid Id { get; set; }
        public string FlagImgId { get; set; }
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
    }
}
