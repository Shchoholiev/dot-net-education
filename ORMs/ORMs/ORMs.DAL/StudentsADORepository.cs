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

        public async Task AddAsync(Student student)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var dormitoryId = student.Dormitory?.Id.ToString() ?? "NULL";

                    var command = new SqlCommand(
                        $"INSERT INTO dbo.[Students] " +
                        $"VALUES (N'{student.Name}', N'{student.Surname}', {student.Age}, {dormitoryId}, " +
                                $"{student.Department.Id}); " +
                        $"SELECT CAST(SCOPE_IDENTITY() AS INT)", connection);
                    var studentId = (int)await command.ExecuteScalarAsync();

                    var insertRecordBook = new SqlCommand($"INSERT INTO dbo.[RecordBooks] " +
                                      $"VALUES ({student.RecordBook.AverageMark}, {studentId})", connection);
                    await insertRecordBook.ExecuteNonQueryAsync();
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
            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(
                        $"DELETE FROM dbo.[Students] WHERE Students.Id = {id}", connection);

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

        public async Task<List<Student>> GetAllAsync()
        {
            var students = new List<Student>();

            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(
                    $"SELECT " +
                        $"Students.Id, " +
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
                        $"LEFT JOIN dbo.[Dormitories] ON Students.DormitoryId = Dormitories.Id", 
                    connection);

                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            Dormitory dormitory = null;
                            var a = reader["DormitoryId"];
                            if (!reader.IsDBNull(reader.GetOrdinal("DormitoryId")))
                            {
                                dormitory = new Dormitory
                                {
                                    Id = (int)reader["DormitoryId"],
                                    Address = reader["Address"].ToString(),
                                };
                            }
                            var student = new Student
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Age = (int)reader["Age"],
                                Dormitory = dormitory,
                                RecordBook = new RecordBook
                                {
                                    Id = (int)reader["RecordBookId"],
                                    AverageMark = (int)reader["AverageMark"],
                                },
                                Department = new Department 
                                { 
                                    Id = (int)reader["DepartmentId"],
                                    Name = reader["DepartmentName"].ToString(),
                                }
                            };
                            students.Add(student);
                        }
                    }
                    reader.Close();
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
            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(
                    $"SELECT " +
                        $"Students.Id, " +
                        $"Students.[Name], " +
                        $"Students.Surname, " +
                        $"Students.Age, " +
                        $"RecordBooks.Id as [RecordBookId], " +
                        $"AverageMark, " +
                        $"DepartmentId, " +
                        $"Departments.[Name] as [DeratmentName], " +
                        $"DormitoryId, " +
                        $"[Address] " +
                    $"FROM dbo.[Students] " +
                        $"LEFT JOIN dbo.[RecordBooks] ON Students.Id = RecordBooks.StudentId " +
                        $"LEFT JOIN dbo.[Departments] ON Students.DepartmentId = Departments.Id " +
                        $"LEFT JOIN dbo.[Dormitories] ON Students.DormitoryId = Dormitories.Id " +
                    $"WHERE Students.Id = {id}",
                    connection);

                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            Dormitory dormitory = null;
                            var a = reader["DormitoryId"];
                            if (!reader.IsDBNull(reader.GetOrdinal("DormitoryId")))
                            {
                                dormitory = new Dormitory
                                {
                                    Id = (int)reader["DormitoryId"],
                                    Address = reader["Address"].ToString(),
                                };
                            }
                            student = new Student
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Age = (int)reader["Age"],
                                Dormitory = dormitory,
                                RecordBook = new RecordBook
                                {
                                    Id = (int)reader["RecordBookId"],
                                    AverageMark = (int)reader["AverageMark"],
                                },
                                Department = new Department
                                {
                                    Id = (int)reader["DepartmentId"],
                                    Name = reader["DeratmentName"].ToString(),
                                }
                            };
                        }
                    }
                    reader.Close();
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
            using (var connection = new SqlConnection(this._connectionString))
            {
                try
                {
                    connection.Open();
                    var dormitoryId = student.Dormitory?.Id.ToString() ?? "NULL";

                    var command = new SqlCommand(
                        $"UPDATE dbo.[Students] " +
                        $"SET Name = N'{student.Name}', " +
                            $"Surname = N'{student.Surname}', " +
                            $"Age = {student.Age}, " +
                            $"DormitoryId = {dormitoryId}, " +
                            $"DepartmentId = {student.Department.Id} " +
                        $"WHERE Students.Id = {student.Id}; " +

                        $"UPDATE dbo.[RecordBooks] " +
                        $"SET AverageMark = {student.RecordBook.AverageMark}" +
                        $"WHERE RecordBooks.Id = {student.RecordBook.Id}", connection);

                    await command.ExecuteScalarAsync();
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

        public void Attach(object entity) { }
    }
}
