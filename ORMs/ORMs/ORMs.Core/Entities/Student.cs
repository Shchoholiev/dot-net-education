namespace ORMs.Core.Entities
{
    public class Student : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public Dormitory? Dormitory { get; set; }

        public RecordBook RecordBook { get; set; }

        public Department Department { get; set; }

        public override string ToString()
        {
            var student = $"{this.Name} {this.Surname} {this.Age} years old, studies at the department {this.Department.Name}," +
                          $" has average mark {this.RecordBook.AverageMark}";
            student += (this.Dormitory != null) ? $" and lives in the dormitory at {this.Dormitory.Address}" : "";
            return student;
        }
    }
}
