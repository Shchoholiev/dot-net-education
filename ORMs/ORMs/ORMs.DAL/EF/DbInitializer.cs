using ORMs.Core.Entities;

namespace ORMs.DAL.EF
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var recordBook1 = new RecordBook { AverageMark = 22 };
            var recordBook2 = new RecordBook { AverageMark = 95 };
            var recordBook3 = new RecordBook { AverageMark = 67 };

            var building = new Building { Address = "Prospekt Nauki, 14" };
            context.Buildings.Add(building);
            context.SaveChanges();

            var department1 = new Department { Name = "Software engineering", Building = building };
            var department2 = new Department { Name = "Computer science", Building = building };

            context.Departments.Add(department1);
            context.Departments.Add(department2);

            context.SaveChanges();

            var dormitory1 = new Dormitory { Address = "Bakulina, 10" };
            var dormitory2 = new Dormitory { Address = "Bakulina, 12" };

            context.Dormitories.Add(dormitory1);
            context.Dormitories.Add(dormitory2);

            context.SaveChanges();

            var teacher1 = new Teacher { FullName = "Gleb Tereshchenko", Department = department1 };
            var teacher2 = new Teacher { FullName = "Alexander Osyka", Department = department1 };
            var teacher3 = new Teacher { FullName = "Elena Voloshchuk", Department = department2 };

            context.Teachers.Add(teacher1);
            context.Teachers.Add(teacher2);
            context.Teachers.Add(teacher3);

            context.SaveChanges();

            var student1 = new Student { Name = "Petya", Surname = "Nabatov", Age = 19, RecordBook = recordBook1, 
                                         Department = department2, Dormitory = dormitory2 };
            var student2 = new Student { Name = "Vasya", Surname = "Pupkin", Age = 18, RecordBook = recordBook2, 
                                         Department = department1, Dormitory = dormitory1 };
            var student3 = new Student { Name = "Tolia", Surname = "Ivanov", Age = 21, RecordBook = recordBook3, 
                                         Department = department1 };
            
            context.Students.Add(student1);
            context.Students.Add(student2);
            context.Students.Add(student3);

            context.SaveChanges();
        }
    }
}

