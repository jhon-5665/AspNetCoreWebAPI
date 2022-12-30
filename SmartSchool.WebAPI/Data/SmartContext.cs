using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) {}
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<StudentDiscipline>? StudentsDisciplines { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discipline>? Disciplines { get; set; }
        public DbSet<Teacher> Teachers { get; set; }        
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentDiscipline>().HasKey(SD => new {SD.StudentId, SD.DisciplineId});

            builder.Entity<StudentCourse>().HasKey(SC => new {SC.StudentId, SC.CourseId});

            builder.Entity<Teacher>().HasData(new List<Teacher>()
            {
                new Teacher(1, 1, "Lauro", "Oliveira"),
                new Teacher(2, 2, "Roberto", "Soares"),
                new Teacher(3, 3, "Ronaldo", "Marconi"),
                new Teacher(4, 4, "Rodrigo", "Carvalho"),
                new Teacher(5, 5, "Alexandre", "Montanha"),
            });

            builder.Entity<Course>().HasData(new List<Course>
            {
                new Course(1, "Information Technology"),
                new Course(2, "Information Systems"),
                new Course(3, "Computer Science")                 
            });
            
            builder.Entity<Discipline>().HasData(new List<Discipline>
            {
                new Discipline(1, "Math", 1, 1),
                new Discipline(2, "Math", 1, 3),
                new Discipline(3, "Physics", 2, 3),
                new Discipline(4, "Portuguese", 3, 1),
                new Discipline(5, "English", 4, 1),
                new Discipline(6, "English", 4, 2),
                new Discipline(7, "English", 4, 3),
                new Discipline(8, "Programing", 5, 1),
                new Discipline(9, "Programing", 5, 2),
                new Discipline(10, "Programing", 5, 3)
            });
            
            builder.Entity<Student>().HasData(new List<Student>()
            {
                new Student(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("30/12/2005")),
                new Student(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("30/12/2005")),
                new Student(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("30/12/2005")),
                new Student(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("30/12/2005")),
                new Student(5, 5, "Lucas", "Machado", "565685415", DateTime.Parse("30/12/2005")),
                new Student(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("30/12/2005")),
                new Student(7, 7, "Paulo", "José", "9874512", DateTime.Parse("30/12/2005"))
            });

            builder.Entity<StudentDiscipline>().HasData(new List<StudentDiscipline>() 
            {
                new StudentDiscipline() {StudentId = 1, DisciplineId = 2 },
                new StudentDiscipline() {StudentId = 1, DisciplineId = 4 },
                new StudentDiscipline() {StudentId = 1, DisciplineId = 5 },
                new StudentDiscipline() {StudentId = 2, DisciplineId = 1 },
                new StudentDiscipline() {StudentId = 2, DisciplineId = 2 },
                new StudentDiscipline() {StudentId = 2, DisciplineId = 5 },
                new StudentDiscipline() {StudentId = 3, DisciplineId = 1 },
                new StudentDiscipline() {StudentId = 3, DisciplineId = 2 },
                new StudentDiscipline() {StudentId = 3, DisciplineId = 3 },
                new StudentDiscipline() {StudentId = 4, DisciplineId = 1 },
                new StudentDiscipline() {StudentId = 4, DisciplineId = 4 },
                new StudentDiscipline() {StudentId = 4, DisciplineId = 5 },
                new StudentDiscipline() {StudentId = 5, DisciplineId = 4 },
                new StudentDiscipline() {StudentId = 5, DisciplineId = 5 },
                new StudentDiscipline() {StudentId = 6, DisciplineId = 1 },
                new StudentDiscipline() {StudentId = 6, DisciplineId = 2 },
                new StudentDiscipline() {StudentId = 6, DisciplineId = 3 },
                new StudentDiscipline() {StudentId = 6, DisciplineId = 4 },
                new StudentDiscipline() {StudentId = 7, DisciplineId = 1 },
                new StudentDiscipline() {StudentId = 7, DisciplineId = 2 },
                new StudentDiscipline() {StudentId = 7, DisciplineId = 3 },
                new StudentDiscipline() {StudentId = 7, DisciplineId = 4 },
                new StudentDiscipline() {StudentId = 7, DisciplineId = 5 }
            });
        }
    }
}