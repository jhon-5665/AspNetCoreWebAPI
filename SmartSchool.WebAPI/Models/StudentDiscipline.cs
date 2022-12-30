namespace SmartSchool.WebAPI.Models
{
    public class StudentDiscipline
    {
        public StudentDiscipline() { }
        public StudentDiscipline(int studentId, int disciplineId)
        {
            this.StudentId = studentId;            
            this.DisciplineId = disciplineId;          
        }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int DisciplineId { get; set; }
        public Discipline? Discipline { get; set; }
    }
}