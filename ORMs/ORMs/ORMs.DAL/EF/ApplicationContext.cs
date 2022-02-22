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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"server=localhost\SQLEXPRESS01;database=University;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Dormitory)
                .WithMany(d => d.Students);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.RecordBook)
                .WithOne(r => r.Student);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students);

            modelBuilder.Entity<RecordBook>()
                .HasOne(r => r.Student)
                .WithOne(s => s.RecordBook)
                .HasForeignKey<RecordBook>(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers);

            modelBuilder.Entity<Dormitory>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Dormitory);

            modelBuilder.Entity<Building>()
                .HasMany(b => b.Departments);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Teachers)
                .WithOne(t => t.Department);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Department);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Dormitory> Dormitories { get; set; }

        public DbSet<RecordBook> RecordBooks { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
