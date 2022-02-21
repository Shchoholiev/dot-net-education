using ORMs.Core.Entities;
using ORMs.DAL.IGenericRepository;
using System.Data.SqlClient;

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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
