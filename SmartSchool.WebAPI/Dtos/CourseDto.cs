namespace SmartSchool.WebAPI.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;     
        public IEnumerable<DisciplineDto>? Disciplines { get; set; }
    }
}