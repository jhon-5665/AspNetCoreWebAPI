namespace SmartSchool.WebAPI.Dtos
{
    public class StudentRegisterDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;        
    }
}