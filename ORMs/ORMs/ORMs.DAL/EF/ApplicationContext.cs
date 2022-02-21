using Microsoft.EntityFrameworkCore;
using ORMs.Core.Entities;

namespace ORMs.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=University;integrated security=True;
        //            MultipleActiveResultSets=True;App=EntityFramework;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Dormitory> Dormitories { get; set; }

        public DbSet<RecordBook> RecordBooks { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
