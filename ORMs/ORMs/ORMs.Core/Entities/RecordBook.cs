namespace ORMs.Core.Entities
{
    public class RecordBook : EntityBase
    {
        public int AverageMark { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
