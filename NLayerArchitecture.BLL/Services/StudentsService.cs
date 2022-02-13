using NLayerArchitecture.BLL.Infrastructure;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.DAL.Repository;

namespace NLayerArchitecture.BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IRepository _repository;

        public StudentsService(IRepository repository)
        {
            this._repository = repository;
        }

        public void Add(string name, string Surname, int age, string favouriteSubject)
        {
            var student = new Student
            {
                Name = name,
                Surname = Surname,
                Age = age,
                FavouriteSubject = favouriteSubject
            };

            this._repository.Add(student);
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public Student GetStudent(int id)
        {
            return this._repository.GetStudent(id);
        }

        public List<Student> GetStudents()
        {
            return this._repository.GetStudents();
        }
    }
}
