using NLayerArchitecture.DAL.Entities;
using System.Text.Json;

namespace NLayerArchitecture.DAL.Repository
{
    public class JsonRepository : IRepository
    {
        private readonly string _filePath;

        public JsonRepository(string filePath)
        {
            this._filePath = filePath;
        }

        public void Add(Student student)
        {
            var json = JsonSerializer.Serialize(student);
            Save(json);
        }

        public void Delete(int id)
        {
            var student = this.GetStudent(id);
            var students = this.GetStudents();
            students.Remove(student);

            this.Save(students);
        }

        public Student GetStudent(int id)
        {
            var students = this.GetStudents();
            return students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>();

            string line;
            using (var sr = new StreamReader(_filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var student = JsonSerializer.Deserialize<Student>(line);
                    students.Add(student);
                }
            }

            return students;
        }

        private void Save(string json)
        {
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(json);
            }
        }

        private void Save(IEnumerable<Student> students)
        {
            File.Delete(_filePath);
            using (File.Create(_filePath)) { }

            foreach (var student in students)
            {
                var json = JsonSerializer.Serialize(student);
                this.Save(json);
            }
        }
    }
}
