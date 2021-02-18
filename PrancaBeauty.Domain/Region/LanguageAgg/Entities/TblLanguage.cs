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
        public string Name { get; set; }
        public string Code { get; set; }
        public string NativeName { get; set; }
        public bool IsRtl { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TblTemplate> TblTemplates { get; set; }
        public virtual ICollection<TblSetting> TblSettings { get; set; }
    }
}
