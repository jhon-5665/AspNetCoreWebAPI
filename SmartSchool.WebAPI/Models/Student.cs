namespace SmartSchool.WebAPI.Models
{
    public class Student
    {
        public Student() { }

        public Student(int id, string name, string surname, string telephone)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Telephone { get; set; } = string.Empty;
        public IEnumerable<StudentDiscipline>? StudentsDisciplines { get; set; }
    }
}