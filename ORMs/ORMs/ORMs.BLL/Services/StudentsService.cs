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

        public async Task Add(string name, string Surname, int age, int dormitoryId, int averageMark, int departmentId)
        {
            var dormitory = (dormitoryId != 0) ? new Dormitory { Id = dormitoryId } : null;

            var student = new Student
            {
                Name = name,
                Surname = Surname,
                Age = age,
                Dormitory = dormitory,
                RecordBook = new RecordBook { AverageMark = averageMark },
                Department = new Department { Id = departmentId }
            };

            this._repository.Attach(student);
            await this._repository.AddAsync(student);
        }

        public async Task Delete(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task Update(int id, string name, string Surname, int age, int dormitoryId, int averageMark, int departmentId)
        {
            var student = await this._repository.GetOneAsync(id, s => s.RecordBook, s => s.Department, s => s.Dormitory);

            var dormitory = (dormitoryId != 0) ? new Dormitory { Id = dormitoryId } : null;
            student.Name = name;
            student.Surname = Surname;
            student.Age = age;
            student.RecordBook.AverageMark = averageMark;
            student.Dormitory = dormitory;
            student.Department = new Department { Id = departmentId };
            this._repository.Attach(student);

            await this._repository.UpdateAsync(student);
        }

        public async Task<Student> GetStudent(int id)
        {
            return await this._repository.GetOneAsync(id, s => s.RecordBook, s => s.Department, s => s.Dormitory);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await this._repository.GetAllAsync(s => s.RecordBook, s => s.Department, s => s.Dormitory);
        }
    }
}
