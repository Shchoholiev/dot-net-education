using ORMs.Core.Entities;

namespace ORMs.BLL.Infrastructure
{
    public interface IStudentsService
    {
        Task Add(string name, string Surname, int age, int dormitoryId, int averageMark, int departmentId);

        Task Delete(int id);

        Task Update(int id, string name, string Surname, int age, int dormitoryId, int averageMark, int departmentId);

        Task<Student> GetStudent(int id);

        Task<List<Student>> GetStudents();
    }
}