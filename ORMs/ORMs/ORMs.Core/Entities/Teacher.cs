namespace ORMs.Core.Entities
{
    public class Teacher : EntityBase
    {
        public string FullName { get; set; }

        public Department Department { get; set; }
    }
}
