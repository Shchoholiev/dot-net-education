namespace NLayerArchitecture.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string FavouriteSubject { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, {Age} years old {Name} {Surname} have favourite subject: {FavouriteSubject} ";
        }
    }
}
