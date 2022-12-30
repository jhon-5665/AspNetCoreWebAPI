using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) {}
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline>? Disciplines { get; set; }
        public DbSet<StudentDiscipline>? StudentsDisciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentDiscipline>().HasKey(SD => new {SD.StudentId, SD.DisciplineId});

            builder.Entity<Teacher>().HasData(new List<Teacher>()
            {
                new Teacher(1, "Lauro"),
                new Teacher(2, "Roberto"),
                new Teacher(3, "Ronaldo"),
                new Teacher(4, "Rodrigo"),
                new Teacher(5, "Alexandre"),
            });
            
            builder.Entity<Discipline>().HasData(new List<Discipline>
            {
                new Discipline(1, "Math", 1),
                new Discipline(2, "Physics", 2),
                new Discipline(3, "Portuguese", 3),
                new Discipline(4, "English", 4),
                new Discipline(5, "Programming ", 5)
            });
            
            builder.Entity<Student>().HasData(new List<Student>()
            {
                new Student(1, "Marta", "Kent", "33225555"),
                new Student(2, "Paula", "Isabela", "3354288"),
                new Student(3, "Laura", "Antonia", "55668899"),
                new Student(4, "Luiza", "Maria", "6565659"),
                new Student(5, "Lucas", "Machado", "565685415"),
                new Student(6, "Pedro", "Alvares", "456454545"),
                new Student(7, "Paulo", "José", "9874512")
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