namespace SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// This is the Student DTO to Register.
    /// </summary>
    public class StudentRegisterDto
    {
        /// <summary>
        /// Bank identifier and key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Student Key, for other business at the Institution
        /// </summary>
        public int Registration { get; set; }
        /// <summary>
        /// Name and First name or Last name of the Student
        /// </summary>
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;        
    }
}