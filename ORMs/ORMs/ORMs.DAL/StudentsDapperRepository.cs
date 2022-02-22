using ORMs.Core.Entities;
using ORMs.DAL.IGenericRepository;
using System.Linq.Expressions;
using Dapper;
using System.Data.SqlClient;

namespace ORMs.DAL
{
    public class StudentsDapperRepository : IGenericRepository<Student>
    {
        private readonly string _connectionString;

        public StudentsDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(Student student)
        {
            var dormitoryId = student.Dormitory?.Id.ToString() ?? "NULL";
            var query = $"INSERT INTO dbo.[Students] " +
                        $"VALUES (@Name, @Surname, @Age, {dormitoryId}, {student.Department.Id}); " +
                        $"SELECT CAST(SCOPE_IDENTITY() AS INT)";

            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();

                    var studentId = await connection.ExecuteScalarAsync(query, student);
                    var insertRecordBook = $"INSERT INTO dbo.[RecordBooks] " +
                                           $"VALUES ({student.RecordBook.AverageMark}, {studentId})";
                    
                    await connection.ExecuteAsync(insertRecordBook, student);
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

        public async Task DeleteAsync(int id)
        {
            var query = $"DELETE FROM dbo.[Students] WHERE Students.Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(query, new { Id = id });
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

        public async Task<List<Student>> GetAllAsync()
        {
            var students = new List<Student>();

            var query = 
                $"SELECT " +
                    $"Students.Id AS [Id], " +
                    $"Students.[Name], " +
                    $"Students.Surname, " +
                    $"Students.Age, " +
                    $"RecordBooks.Id as [RecordBookId], " +
                    $"AverageMark, " +
                    $"DepartmentId, " +
                    $"Departments.[Name] as [DepartmentName], " +
                    $"DormitoryId, " +
                    $"[Address] " +
                $"FROM dbo.[Students] " +
                    $"LEFT JOIN dbo.[RecordBooks] ON Students.Id = RecordBooks.StudentId " +
                    $"LEFT JOIN dbo.[Departments] ON Students.DepartmentId = Departments.Id " +
                    $"LEFT JOIN dbo.[Dormitories] ON Students.DormitoryId = Dormitories.Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync(query);
                    foreach (var row in result)
                    {
                        Dormitory dormitory = null;
                        if (row.DormitoryId != null)
                        {
                            dormitory = new Dormitory
                            {
                                Id = row.DormitoryId,
                                Address = row.Address,
                            };
                        }
                        var student = new Student
                        {
                            Id = row.Id,
                            Name = row.Name,
                            Surname = row.Surname,
                            Age = row.Age,
                            Dormitory = dormitory,
                            Department = new Department
                            {
                                Id = row.DepartmentId,
                                Name = row.DepartmentName,
                            },
                            RecordBook = new RecordBook
                            {
                                Id = row.RecordBookId,
                                AverageMark = row.AverageMark,
                            }
                        };

                        students.Add(student);
                    }
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

            return students;
        }

        public async Task<List<Student>> GetAllAsync(params Expression<Func<Student, object>>[] includeProperties)
        {
            return await this.GetAllAsync();
        }

        public async Task<Student> GetOneAsync(int id)
        {
            Student student = null;

            var query =
                $"SELECT " +
                    $"Students.Id AS [Id], " +
                    $"Students.[Name], " +
                    $"Students.Surname, " +
                    $"Students.Age, " +
                    $"RecordBooks.Id as [RecordBookId], " +
                    $"AverageMark, " +
                    $"DepartmentId, " +
                    $"Departments.[Name] as [DepartmentName], " +
                    $"DormitoryId, " +
                    $"[Address] " +
                $"FROM dbo.[Students] " +
                    $"LEFT JOIN dbo.[RecordBooks] ON Students.Id = RecordBooks.StudentId " +
                    $"LEFT JOIN dbo.[Departments] ON Students.DepartmentId = Departments.Id " +
                    $"LEFT JOIN dbo.[Dormitories] ON Students.DormitoryId = Dormitories.Id " +
                $"WHERE Students.Id = {id}";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync(query);
                    Dormitory dormitory = null;
                    if (result.DormitoryId != null)
                    {
                        dormitory = new Dormitory
                        {
                            Id = result.DormitoryId,
                             Address = result.Address,
                        };
                    }
                    student = new Student
                    {
                        Id = result.Id,
                        Name = result.Name,
                        Surname = result.Surname,
                        Age = result.Age,
                        Dormitory = dormitory,
                        Department = new Department
                        {
                            Id = result.DepartmentId,
                            Name = result.DepartmentName,
                        },
                        RecordBook = new RecordBook
                        {
                            Id = result.RecordBookId,
                            AverageMark = result.AverageMark,
                        }
                    };
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

            return student;
        }

        public async Task<Student> GetOneAsync(int id, params Expression<Func<Student, object>>[] includeProperties)
        {
            return await this.GetOneAsync(id);
        }

        public async Task UpdateAsync(Student student)
        {
            var dormitoryId = student.Dormitory?.Id.ToString() ?? "NULL";

            var updateStudent = 
                $"UPDATE dbo.[Students] " +
                $"SET Name = @Name, Surname = @Surname, Age = @Age, " +
                    $"DormitoryId = {dormitoryId}, DepartmentId = {student.Department.Id} " +
                $"WHERE Students.Id = @Id";

            var updateRecordBook = $"UPDATE dbo.[RecordBooks] SET AverageMark = @AverageMark WHERE RecordBooks.Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(updateStudent, student);
                    await connection.ExecuteAsync(updateRecordBook, student.RecordBook);
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

        public void Attach(object student) { }
    }
}
