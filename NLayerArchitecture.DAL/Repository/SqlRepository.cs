using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.DAL.EF;

namespace NLayerArchitecture.DAL.Repository
{
    public class SqlRepository : IRepository
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<Student> _table;

        public SqlRepository()
        {
            this._db = new ApplicationContext();
            this._table = _db.Set<Student>();
            _db.Database.EnsureCreated();
        }

        public void Add(Student student)
        {
            this._table.Add(student);
            this.Save();
        }

        public void Delete(int id)
        {
            var student = this.GetStudent(id);
            if (student != null)
            {
                this._table.Remove(student);
            }
            this.Save();
        }

        public Student GetStudent(int id)
        {
            return this._table.Find(id);
        }

        public List<Student> GetStudents()
        {
            return _table.ToList();
        }

        private void Save()
        {
            this._db.SaveChanges();
        }
    }
}
