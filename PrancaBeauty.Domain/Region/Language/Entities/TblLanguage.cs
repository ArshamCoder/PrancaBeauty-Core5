using Framework.Domain;
using System;

namespace PrancaBeauty.Domain.Region.Language.Entities
{
    public class TblLanguage : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string NativeName { get; set; }
        public bool IsRtl { get; set; }
        public bool IsActive { get; set; }
    }
}
