namespace SmartSchool.WebAPI.V1.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public IEnumerable<DisciplineDto> Disciplines { get; set; }
    }
}