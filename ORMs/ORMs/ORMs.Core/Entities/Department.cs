namespace ORMs.Core.Entities
{
    public class Department : EntityBase
    {
        public string Name { get; set; }

        public Building Building { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Student> Students { get; set; }
    }
}
