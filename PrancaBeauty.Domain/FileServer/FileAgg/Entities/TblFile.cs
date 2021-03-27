using Framework.Domain;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;

namespace PrancaBeauty.Domain.FileServer.FileAgg.Entities
{
    public class TblFile : IEntity
    {
        public Guid Id { get; set; }
        public Guid FileServerId { get; set; }
        public Guid? UserId { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public long SizeOnDisk { get; set; }
        public string MimeType { get; set; } // image/jpg, image/png , application/zip
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }

        public virtual TblFileServer TblFileServer { get; set; }
        public virtual TblUser TblUser { get; set; }



    }
}
