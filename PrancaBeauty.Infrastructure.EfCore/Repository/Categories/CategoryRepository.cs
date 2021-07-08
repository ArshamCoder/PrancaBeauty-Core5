using Framework.Infrastructure;
using PrancaBeauty.Domain.Categories.Contracts;
using PrancaBeauty.Domain.Categories.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Categories
{
    public class CategoryRepository : BaseRepository<TblCategoris>, ICategoryRepository
    {
        public CategoryRepository(MainContext context) : base(context)
        {

        }
    }
}
