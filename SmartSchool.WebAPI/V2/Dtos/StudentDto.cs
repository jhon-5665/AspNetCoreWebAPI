namespace SmartSchool.WebAPI.V2.Dtos
{
    public class StudentDto
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
        public string? Name { get; set; }     
        public string? Telephone { get; set; }
        /// <summary>
        /// This age is the calculation related to the Student's date of birth
        /// </summary>
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Activate or not the Student
        /// </summary>   
        public bool Active { get; set; }
        
    }
}