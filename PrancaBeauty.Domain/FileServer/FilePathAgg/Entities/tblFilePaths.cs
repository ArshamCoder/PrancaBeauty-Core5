using System;
using System.Collections.Generic;
using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;

namespace PrancaBeauty.Domain.FileServer.FilePathAgg.Entities
{
    public class tblFilePaths : IEntity
    {
        public Guid Id { get; set; }
        public Guid FileServerId { get; set; }
        public string Path { get; set; }

        public virtual TblFileServer tblFileServer { get; set; }
        public virtual ICollection<TblFile> tblFiles { get; set; }
    }
}
