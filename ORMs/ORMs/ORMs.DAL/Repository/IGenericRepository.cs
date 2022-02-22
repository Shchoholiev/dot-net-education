using ORMs.Core.Entities;
using System.Linq.Expressions;

namespace ORMs.DAL.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task Add(TEntity entity);

        Task<TEntity> GetOne(int id);

        void Attach(object entity);

        Task<TEntity> GetOne(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}
