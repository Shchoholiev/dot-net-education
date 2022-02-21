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
    }
}
