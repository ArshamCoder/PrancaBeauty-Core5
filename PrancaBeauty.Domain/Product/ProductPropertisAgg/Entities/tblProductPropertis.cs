using Framework.Domain;
using PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Entities;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities
{
    public class tblProductPropertis : IEntity
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }

        public virtual tblProductTopic tblProductTopic { get; set; }
        public virtual ICollection<tblProductPropertis_Translates> tblProductPropertis_Translates { get; set; }
        public virtual ICollection<tblProductPropertiesValues> tblProductPropertiesValues { get; set; }
    }
}
