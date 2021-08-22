using Framework.Domain;
using PrancaBeauty.Domain.Keywords.KeywordAgg.Entities;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Keywords.Keywords_Products.Entities
{
    public class tblKeywords_Products : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid KeywordId { get; set; }
        /// <summary>
        /// درصد تشابه
        /// </summary>
        public int Similarity { get; set; }

        public virtual tblKeywords tblKeywords { get; set; }
        public virtual tblProducts tblProducts { get; set; }

    }
}
