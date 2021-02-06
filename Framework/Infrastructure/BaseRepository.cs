using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Infrastructure
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext dbContext;
        public DbSet<TEntity> DbEntities { get; }

        public BaseRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            DbEntities = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get => DbEntities;
        public IQueryable<TEntity> GetNoTraking => DbEntities.AsNoTracking();
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true)
        {
            await DbEntities.AddAsync(entity, cancellationToken);

            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRengeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true)
        {
            await DbEntities.AddRangeAsync(entities, cancellationToken);

            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.Remove(entity);

            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteRengeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.RemoveRange(entities);

            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.Update(entity);

            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateRengeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.UpdateRange(entities);

            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> GetById(CancellationToken cancellationToken, params object[] ids)
        {
            return await DbEntities.FindAsync(ids, cancellationToken);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
