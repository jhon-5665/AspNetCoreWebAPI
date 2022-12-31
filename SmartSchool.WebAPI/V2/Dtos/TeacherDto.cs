namespace SmartSchool.WebAPI.V2.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public int Record { get; set; }
        public string Name { get; set; } = string.Empty;        
        public string Telephone { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public IEnumerable<DisciplineDto>? Disciplines { get; set; }
    }
}