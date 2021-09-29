using System;
using System.Collections.Generic;
using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;

namespace PrancaBeauty.Domain.FileServer.FileTypeAgg.Entities
{
    public class tblFileTypes : IEntity
    {
        public Guid Id { get; set; }
        public string IconUrl { get; set; }
        public string MimeType { get; set; }
        public string Extentions { get; set; }

        public virtual ICollection<TblFile> tblFiles { get; set; }
    }
}
