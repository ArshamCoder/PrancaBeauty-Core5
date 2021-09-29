using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.FilePathAgg.Contracts;
using PrancaBeauty.Domain.FileServer.FilePathAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EFCore.Repository.FilePath
{
    public class FilePathRepository : BaseRepository<tblFilePaths>, IFilePathRepository
    {
        public FilePathRepository(MainContext Context) : base(Context)
        {

        }
    }
}
