namespace SmartSchool.WebAPI.V1.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public int Record { get; set; }
        public string Name { get; set; }       
        public string Telephone { get; set; }
        public bool Active { get; set; } = true;
        public IEnumerable<DisciplineDto> Disciplines { get; set; }
    }
}