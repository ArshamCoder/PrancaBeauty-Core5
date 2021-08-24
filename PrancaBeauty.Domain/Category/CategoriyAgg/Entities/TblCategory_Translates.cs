using Framework.Domain;
using PrancaBeauty.Domain.Region.LanguageAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Category.CategoriyAgg.Entities
{
    public class TblCategory_Translates : IEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LangId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public virtual TblCategoris tblCategoris { get; set; }
        public virtual TblLanguage TblLanguage { get; set; }
    }
}
