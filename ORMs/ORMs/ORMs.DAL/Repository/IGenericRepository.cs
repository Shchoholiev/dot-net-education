using ORMs.Core.Entities;

namespace ORMs.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetOne(int id);

        List<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(int id);
    }
}
