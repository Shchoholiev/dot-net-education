using ORMs.BLL.Infrastructure;

namespace ORMs.UI
{
    public class Application
    {
        private readonly IStudentsService _studentsService;

        public Application(IStudentsService studentsService)
        {
            this._studentsService = studentsService;
        }

        public async Task Run()
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
                            await this.GetStudents();
                            break;

                        case 2:
                            await this.GetStudent();
                            break;

                        case 3:
                            await this.AddStudent();
                            break;

                        case 4:
                            await this.Delete();
                            break;

                        default:
                            break;
                    }
                }

            } while (input != "q");
        }

        private async Task GetStudents()
        {
            var students = await this._studentsService.GetStudents();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        private async Task GetStudent()
        {
            Console.WriteLine("Enter Id");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = await this._studentsService.GetStudent(id);
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Enter valid Id!");
            }
        }

        private async Task AddStudent()
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

            int dormitoryId;
            while (true)
            {
                Console.WriteLine("Enter Dormitory Id: ");
                if (int.TryParse(Console.ReadLine(), out dormitoryId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid Id!");
                }
            }

            int averageMark;
            while (true)
            {
                Console.WriteLine("Enter Average Mark (0 - 100): ");
                if (int.TryParse(Console.ReadLine(), out averageMark) && averageMark >= 0 && averageMark <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid Average Mark!");
                }
            }

            int departmentId;
            while (true)
            {
                Console.WriteLine("Enter DepartmentId");
                if (int.TryParse(Console.ReadLine(), out departmentId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid Id!");
                }
            }

            await this._studentsService.Add(name, surname, age, dormitoryId, averageMark, departmentId);
            Console.WriteLine("Student Added!");
        }

        private async Task Delete()
        {
            Console.WriteLine("Enter Id");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                await this._studentsService.Delete(id);
                Console.WriteLine("Student Deleted!");
            }
            else
            {
                Console.WriteLine("Enter valid Id!");
            }
        }
    }
}
