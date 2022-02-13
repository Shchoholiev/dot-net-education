using NLayerArchitecture.BLL.Infrastructure;

namespace NLayerArchitecture.UI
{
    public class Application
    {
        private readonly IStudentsService _studentsService;

        public Application(IStudentsService studentsService)
        {
            this._studentsService = studentsService;
        }

        public void Run()
        {
            string input;
            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1 - View all students");
                Console.WriteLine("2 - Get student by Id");
                Console.WriteLine("3 - Add Student");
                Console.WriteLine("4 - Delete Student");
                Console.WriteLine("q - quit application");
                Console.WriteLine("-----------------------------");

                input = Console.ReadLine();
                if (int.TryParse(input, out int n))
                {
                    switch (n)
                    {
                        case 1:
                            this.GetStudents();
                            break;

                        case 2:
                            this.GetStudent();
                            break;

                        case 3:
                            this.AddStudent();
                            break;

                        case 4:
                            this.Delete();
                            break;

                        default:
                            break;
                    }
                }

            } while (input != "q");
        }

        private void GetStudents()
        {
            var students = this._studentsService.GetStudents();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        private void GetStudent()
        {
            Console.WriteLine("Enter Id");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = this._studentsService.GetStudent(id);
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Enter valid Id!");
            }
        }

        private void AddStudent()
        {
            Console.WriteLine("Enter Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Surname: ");
            var surname = Console.ReadLine();

            int age;
            while (true)
            {
                Console.WriteLine("Enter Age: ");
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid age!");
                }
            }

            Console.WriteLine("Enter Favourite Subject");
            var favouriteSubject = Console.ReadLine();

            this._studentsService.Add(name, surname, age, favouriteSubject);
            Console.WriteLine("Student Added!");
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                this._studentsService.Delete(id);
                Console.WriteLine("Student Deleted!");
            }
            else
            {
                Console.WriteLine("Enter valid Id!");
            }
        }
    }
}
