using Microsoft.EntityFrameworkCore;
using ORMs.DAL.IGenericRepository;

namespace ORMs.DAL.EF
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<TEntity> _table;

        public GenericRepository()
        {
            this._db = new ApplicationContext();
            this._table = _db.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await this._table.AddAsync(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
