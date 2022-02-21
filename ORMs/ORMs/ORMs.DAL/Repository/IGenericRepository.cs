using ORMs.Core.Entities;

namespace ORMs.DAL.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);

        Task<TEntity> GetOne(int id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}
