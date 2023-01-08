namespace SmartSchool.WebAPI.V1.Dtos
{
    public class DisciplineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int? PrerequisiteId { get; set; } = null;
        public DisciplineDto Prerequisite { get; set; }
        public int TeacherId { get; set; }
        public TeacherDto Teacher { get; set; }
        public int CourseId { get; set; }
        public CourseDto Course { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}