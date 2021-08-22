using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductTopicAgg.Entities
{
    public class tblProductTopic : IEntity
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public string Name { get; set; }

        public virtual TblFile tblFiles { get; set; }
        public virtual ICollection<tblProductTopic_Translates> tblProductTopic_Translates { get; set; }
        public virtual ICollection<tblProductPropertis> tblProductPropertis { get; set; }
        public virtual ICollection<tblProductReviewsAttribute> tblProductReviewsAttribute { get; set; }
    }
}
