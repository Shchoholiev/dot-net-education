using NLayerArchitecture.Core.Entities;

namespace NLayerArchitecture.BLL.Infrastructure
{
    public interface IStudentsService
    {
        void Add(string name, string Surname, int age, string favouriteSubject);

        void Delete(int id);

        Student GetStudent(int id);

        List<Student> GetStudents();
    }
}
