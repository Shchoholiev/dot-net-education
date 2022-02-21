using ORMs.Core.Entities;
using ORMs.DAL.Repository;
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

        public void Add(Student student)
        {
            var insertRecordBook = new SqlCommand($"INSERT INTO dbo.[RecordBooks]" +
                $"VALUES {student.RecordBook.AverageMark}");

            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var recordBookId = insertRecordBook.ExecuteScalar;
                    var command = new SqlCommand($"INSERT INTO dbo.[Students] " +
                                  $"VALUES {student.Name}, {student.Surname}, {student.Age}, {student.Dormitory?.Id}, " +
                                  $"{recordBookId}, {student.Department.Id}");
                    command.ExecuteNonQuery();
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
