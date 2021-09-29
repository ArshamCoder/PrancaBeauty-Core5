using Framework.Domain;
using PrancaBeauty.Domain.Category.CategoriyAgg.Entities;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Domain.Product.ProductMediaAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Entities;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using PrancaBeauty.Domain.Region.CountryAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using PrancaBeauty.Domain.User.SellerAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;
using PrancaBeauty.Domain.FileServer.FilePathAgg.Entities;
using PrancaBeauty.Domain.FileServer.FileTypeAgg.Entities;

namespace PrancaBeauty.Domain.FileServer.FileAgg.Entities
{
    public class TblFile : IEntity
    {
        public Guid Id { get; set; }
        public Guid FilePathId { get; set; }
        public Guid FileTypeId { get; set; }
        public Guid? UserId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public long SizeOnDisk { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }


        public virtual TblUser tblUser { get; set; }

        public virtual TblFileServer TblFileServer { get; set; }
        public virtual TblUser TblUser { get; set; }
        public virtual tblProductMedia tblProductMedia { get; set; }
        public virtual tblFileTypes tblFileTypes { get; set; }
        public virtual tblFilePaths tblFilePaths { get; set; }
        public virtual ICollection<TblCountries> TblCountries { get; set; }
        public virtual ICollection<TblLanguage> TblLanguages { get; set; }

        public virtual ICollection<TblCategoris> tblCategoris { get; set; }

        public virtual tblProductReviewsMedia tblProductReviewsMedia { get; set; }
        public virtual ICollection<tblProductTopic> tblProductTopic { get; set; }
        public virtual ICollection<tblSeller_Translates> tblSeller_Translates { get; set; }
        public virtual ICollection<TblUser> tblUserProfile { get; set; }
    }
}
