namespace ORMs.Core.Entities
{
    public class Building : EntityBase
    {
        public string Address { get; set; }

        public List<Department> Departments { get; set; }
    }
}
