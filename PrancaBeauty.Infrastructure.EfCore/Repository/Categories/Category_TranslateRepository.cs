using Framework.Infrastructure;
using PrancaBeauty.Domain.Categories.Contracts;
using PrancaBeauty.Domain.Categories.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.Categories
{
    public class Category_TranslateRepository : BaseRepository<TblCategory_Translates>, ICategory_TranslateRepository
    {
        public Category_TranslateRepository(MainContext context) : base(context)
        {

        }
    }
}
