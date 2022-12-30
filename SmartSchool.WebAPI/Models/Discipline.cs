namespace SmartSchool.WebAPI.Models
{
    public class Discipline
    {
        public Discipline() { }
        public Discipline(int id, string name, int teacherId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;            
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public IEnumerable<StudentDiscipline>? StudentsDisciplines { get; set; }
    }
}