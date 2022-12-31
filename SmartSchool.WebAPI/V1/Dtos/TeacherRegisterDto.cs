namespace SmartSchool.WebAPI.V1.Dtos
{
    public class TeacherRegisterDto
    {
        public int Id { get; set; }
        public int Record { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}