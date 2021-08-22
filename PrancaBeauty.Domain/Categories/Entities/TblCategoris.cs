using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.Categories.Entities
{
    public class TblCategoris : IEntity
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }

        public virtual TblCategoris tblCategory_Parent { get; set; }
        public virtual TblFile tblFiles { get; set; }
        public virtual ICollection<TblCategoris> tblCategory_Childs { get; set; }
        public virtual ICollection<TblCategory_Translates> tblCategory_Translates { get; set; }

        public virtual ICollection<tblProducts> tblProducts { get; set; }
    }
}
