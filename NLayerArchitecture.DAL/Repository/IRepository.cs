using NLayerArchitecture.Core.Entities;

namespace NLayerArchitecture.DAL.Repository
{
    public interface IRepository
    {
        void Add(Student student);

        void Delete(int id);

        Student GetStudent(int id);

        List<Student> GetStudents();
    }
}
