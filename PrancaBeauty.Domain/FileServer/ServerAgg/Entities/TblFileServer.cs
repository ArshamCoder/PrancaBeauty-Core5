using Framework.Domain;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using System;
using System.Collections.Generic;

namespace PrancaBeauty.Domain.FileServer.ServerAgg.Entities
{
    public class TblFileServer : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HttpDomin { get; set; }
        public string HttpPath { get; set; }

        /// <summary>
        /// حجم این که چقدر این مسیر ظرفیت اپلود داره
        /// مثلا 10 گیگ
        /// </summary>
        public long Capacity { get; set; } // byte
        public string FtpData { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TblFile> TblFiles { get; set; }
    }
}
