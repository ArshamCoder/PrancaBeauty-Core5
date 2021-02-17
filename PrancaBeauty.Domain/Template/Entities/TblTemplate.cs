using Framework.Domain;
using System;

namespace PrancaBeauty.Domain.Template.Entities
{
    public class TblTemplate : IEntity
    {
        public Guid Id { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string HtmlCode { get; set; }
    }
}
