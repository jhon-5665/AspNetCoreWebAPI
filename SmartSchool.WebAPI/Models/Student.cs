namespace SmartSchool.WebAPI.Models
{
    public class Student
    {
        public Student() { }

        public Student(int id, int registration ,string name, string surname, string telephone, DateTime birthDate)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
            this.BirthDate = birthDate;
        }
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<StudentDiscipline>? StudentsDisciplines { get; set; }
    }
}