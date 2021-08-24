using Framework.Infrastructure;
using PrancaBeauty.Domain.Template.TemplateAgg.Contracts;
using PrancaBeauty.Domain.Template.TemplateAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.Template
{
    public class TemplateRepository : BaseRepository<TblTemplate>, ITemplateRepository
    {
        public TemplateRepository(MainContext context) : base(context)
        {

        }
    }
}
