using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.FileAgg.Contracts;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.FileServer
{
    public class FileRepository : BaseRepository<TblFile>, IFileRepository
    {
        public FileRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
