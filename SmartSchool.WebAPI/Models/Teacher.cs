namespace SmartSchool.WebAPI.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, int record, string name, string surname)
        {
            this.Id = id;
            this.Record = record;
            this.Name = name;
            this.Surname = surname;
        }
        public int Id { get; set; }
        public int Record { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<Discipline>? Disciplines { get; set; }
    }
}