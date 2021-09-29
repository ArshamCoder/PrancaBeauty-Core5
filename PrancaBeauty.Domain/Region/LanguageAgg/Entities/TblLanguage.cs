﻿using Framework.Domain;
using PrancaBeauty.Domain.Category.CategoriyAgg.Entities;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Entities;
using PrancaBeauty.Domain.Region.CityAgg.Entities;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Domain.Region.ProvinceAgg.Entities;
using PrancaBeauty.Domain.Setting.SettingAgg.Entities;
using PrancaBeauty.Domain.Template.TemplateAgg.Entities;
using PrancaBeauty.Domain.User.SellerAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;

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

        public Guid CountryId { get; set; }

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
        public virtual ICollection<tblProducts> tblProducts { get; set; }

        public virtual ICollection<tblProductTopic_Translates> tblProductTopic_Translates { get; set; }
        public virtual ICollection<tblProductPropertis_Translates> tblProductPropertis_Translates { get; set; }
        public virtual ICollection<tblProductVariants_Translates> tblProductVariants_Translates { get; set; }
        public virtual ICollection<tblSeller_Translates> tblSeller_Translates { get; set; }
        public virtual ICollection<tblProductReviewsAttribute_Translate> tblProductReviewsAttribute_Translate { get; set; }
        public virtual TblCountries tblCountries { get; set; }






    }
}
