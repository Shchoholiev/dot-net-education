using ORMs.BLL.Infrastructure;
using ORMs.Core.Entities;
using ORMs.DAL.Repository;

namespace ORMs.BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IGenericRepository<Student> _repository;

        public StudentsService(IGenericRepository<Student> repository)
        {
            this._repository = repository;
        }

        public void Add(string name, string Surname, int age, int? dormitoryId, int averageMark, int departmentId)
        {
            var dormitory = (dormitoryId != null) ? new Dormitory { Id = (int) dormitoryId } : null;

            var student = new Student
            {
                Name = name,
                Surname = Surname,
                Age = age,        
                Dormitory = dormitory,
                RecordBook = new RecordBook { AverageMark = averageMark },
                Department = new Department { Id = departmentId }
            };

            this._repository.Add(student);
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public Student GetStudent(int id)
        {
            return this._repository.GetOne(id);
        }

        public List<Student> GetStudents()
        {
            return this._repository.GetAll();
        }
    }
}
