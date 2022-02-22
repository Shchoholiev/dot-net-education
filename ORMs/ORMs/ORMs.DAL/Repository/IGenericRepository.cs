using ORMs.Core.Entities;
using System.Linq.Expressions;

namespace ORMs.DAL.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> GetOneAsync(int id);

        void Attach(object entity);

        Task<TEntity> GetOneAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
