using ORMs.Core.Entities;
using ORMs.DAL.IGenericRepository;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ORMs.DAL
{
    public class StudentsADORepository : IGenericRepository<Student>
    {
        private readonly string _connectionString;

        public StudentsADORepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Add(Student student)
        {
            var insertRecordBook = new SqlCommand($"INSERT INTO dbo.[RecordBooks]" +
                $"VALUES {student.RecordBook.AverageMark}");

            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var recordBookId = await insertRecordBook.ExecuteScalarAsync();
                    var command = new SqlCommand($"INSERT INTO dbo.[Students] " +
                                  $"VALUES {student.Name}, {student.Surname}, {student.Age}, {student.Dormitory?.Id}, " +
                                  $"{recordBookId}, {student.Department.Id}");
                    await command.ExecuteNonQueryAsync();
                }                
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection?.Close();
                }
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetOne(int id, params Expression<Func<Student, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAll(params Expression<Func<Student, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task Update(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(object entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, params Expression<Func<Student, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
