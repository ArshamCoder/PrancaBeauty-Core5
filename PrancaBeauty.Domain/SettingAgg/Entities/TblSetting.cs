using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.SettingAgg.Entities
{
    public class TblSetting : IEntity
    {
        public Guid Id { get; set; }

        public Guid LangId { get; set; }
        public string SiteTitle { get; set; }
        public string SiteUrl { get; set; }
        public string SiteDescription { get; set; }
        public string SiteEmail { get; set; }
        public string SitePhoneNumber { get; set; }
        public bool IsInManufacture { get; set; }


        public virtual TblLanguage TblLanguage { get; set; }
    }
}
