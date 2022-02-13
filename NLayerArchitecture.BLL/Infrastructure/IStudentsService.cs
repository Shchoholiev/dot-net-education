using NLayerArchitecture.Core.Entities;

namespace NLayerArchitecture.BLL.Infrastructure
{
    public interface IStudentsService
    {
        void Add(Student student);

        void Delete(int id);

        Student GetStudent(int id);

        List<Student> GetStudents();
    }
}
