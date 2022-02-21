using System.ComponentModel.DataAnnotations;

namespace ORMs.Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
