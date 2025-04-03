using Microsoft.EntityFrameworkCore;
using Mvc_Crud_Practice.Models;

namespace Mvc_Crud_Practice.Database
{
    public class SchoolContextTest
    {
        public SchoolContextTest()
        {
        }

        // Constructeur utilisé pour l'injection de dépendance via le Program.cs
        public SchoolContextTest(DbContextOptions<SchoolContextTest> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ZE-PC-OF-THE-FA\\MSSQLSERVER01;Database=ContosoUniversity;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Course>().HasData(new Course { CourseId = 1, Credits = 5, Title = "C# avancé", Enrollments = new List<Enrollment>() });
            modelBuilder.Entity<Course>().HasData(new Course { CourseId = 2, Credits = 5, Title = "ASP.Net", Enrollments = new List<Enrollment>() });
            modelBuilder.Entity<Course>().HasData(new Course { CourseId = 3, Credits = 5, Title = "Docker", Enrollments = new List<Enrollment>() });

            modelBuilder.Entity<Student>().HasData(new Student { StudentId = 1, FirstMidName = "Cédric", LastName = "BRASSEUR" });
            modelBuilder.Entity<Student>().HasData(new Student { StudentId = 2, FirstMidName = "Jean", LastName = "JACQUES" });
            modelBuilder.Entity<Student>().HasData(new Student { StudentId = 3, FirstMidName = "John", LastName = "DOE" });
            modelBuilder.Entity<Student>().HasData(new Student { StudentId = 4, FirstMidName = "Jane", LastName = "LAMEUFDETARZAN" });

            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { EnrollmentId = 1, Grade = Grade.B, StudentId = 1, CourseId = 1 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { EnrollmentId = 2, Grade = Grade.B, StudentId = 2, CourseId = 1 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { EnrollmentId = 3, Grade = Grade.B, StudentId = 3, CourseId = 1 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { EnrollmentId = 4, Grade = Grade.A, StudentId = 1, CourseId = 2 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { EnrollmentId = 5, Grade = Grade.A, StudentId = 2, CourseId = 2 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { EnrollmentId = 6, Grade = Grade.A, StudentId = 3, CourseId = 3 });
        }
    }
}
