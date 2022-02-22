using Microsoft.EntityFrameworkCore;
using ORMs.Core.Entities;
using ORMs.DAL.IGenericRepository;
using System.Linq.Expressions;

namespace ORMs.DAL.EF
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<TEntity> _table;

        public GenericRepository()
        {
            this._db = new ApplicationContext();
            this._table = _db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._table.AddAsync(entity);
            await this.Save();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this.GetOneAsync(id);
            if (entity != null)
            {
                this._table.Remove(entity);
                await this.Save();
            }
        }

        public async Task<TEntity> GetOneAsync(int id)
        {
            return await this._table.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetOneAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await this.Include(includeProperties).FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return this._table.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await this.Include(includeProperties).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this._table.Update(entity);
            await this.Save();
        }

        public void Attach(object entity)
        {
            this._db.Attach(entity);
        }

        private async Task Save()
        {
            await this._db.SaveChangesAsync();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this._table.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty)
                    => current.Include(includeProperty));
        }
    }
}
