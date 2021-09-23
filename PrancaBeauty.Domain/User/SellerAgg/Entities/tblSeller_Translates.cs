using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.User.SellerAgg.Entities
{
    public class tblSeller_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid LangId { get; set; }
        public Guid SellerId { get; set; }
        public Guid? LogoId { get; set; }
        public string Title { get; set; }

        public virtual TblLanguage tblLanguages { get; set; }
        public virtual tblSellers tblSellers { get; set; }
        public virtual TblFile tblFiles { get; set; }
    }
}
