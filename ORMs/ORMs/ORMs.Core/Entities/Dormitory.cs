namespace ORMs.Core.Entities
{
    public class Dormitory : EntityBase
    {
        public string Address { get; set; }

        public List<Student> Students { get; set; }
    }
}
