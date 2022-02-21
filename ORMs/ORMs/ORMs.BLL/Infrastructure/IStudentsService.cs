using ORMs.Core.Entities;

namespace ORMs.BLL.Infrastructure
{
    public interface IStudentsService
    {
        void Add(string name, string Surname, int age, int? dormitoryId, int averageMark, int departmentId);

        void Delete(int id);

        Student GetStudent(int id);

        List<Student> GetStudents();
    }
}