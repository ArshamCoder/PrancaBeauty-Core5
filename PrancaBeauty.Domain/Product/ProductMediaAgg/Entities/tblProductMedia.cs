using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.Product.ProductAgg.Entities;
using System;

namespace PrancaBeauty.Domain.Product.ProductMediaAgg.Entities
{
    public class tblProductMedia : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FileId { get; set; }
        public int Sort { get; set; }

        public virtual tblProducts tblProducts { get; set; }
        public virtual TblFile tblFiles { get; set; }


    }
}
