using ORMs.BLL.Infrastructure;
using ORMs.Core.Entities;
using ORMs.DAL.IGenericRepository;

namespace ORMs.BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IGenericRepository<Student> _repository;

        public StudentsService(IGenericRepository<Student> repository)
        {
            this._repository = repository;
        }

        public async Task Add(string name, string Surname, int age, int? dormitoryId, int averageMark, int departmentId)
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

            await this._repository.Add(student);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
