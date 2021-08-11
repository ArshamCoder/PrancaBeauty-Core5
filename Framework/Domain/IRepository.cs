using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> DbEntities { get; }
        IQueryable<TEntity> Get { get; }
        IQueryable<TEntity> GetNoTraking { get; }

        Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true);
        Task AddRengeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true);


        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true);
        Task DeleteRengeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true);


        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true);
        Task UpdateRengeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true);

        Task<TEntity> GetById(CancellationToken cancellationToken, params object[] ids);
        Task<int> SaveChangeAsync();

        Task DeleteRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken, bool AutoSave = true);
        Task AddRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken, bool AutoSave = true);
    }
}
