using Framework.Domain;
using PrancaBeauty.Domain.Keywords.Keywords_Products.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Keywords.KeywordAgg.Entities
{
    public class tblKeywords : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<tblKeywords_Products> tblKeywords_Products { get; set; }
    }
}
