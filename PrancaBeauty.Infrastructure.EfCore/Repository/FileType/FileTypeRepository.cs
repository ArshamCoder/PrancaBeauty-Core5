using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.FileTypeAgg.Contracts;
using PrancaBeauty.Domain.FileServer.FileTypeAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.FileType
{
    public class FileTypeRepository : BaseRepository<tblFileTypes>, IFileTypeRepository
    {
        public FileTypeRepository(MainContext Context) : base(Context)
        {

        }
    }
}
