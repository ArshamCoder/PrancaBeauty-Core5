using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.ServerAgg.Contracts;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;

namespace PrancaBeauty.Infrastructure.EfCore.Repository.FileServer
{
    public class FileServerRepository : BaseRepository<TblFileServer>, IFileServerRepository
    {
        public FileServerRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
