namespace SmartSchool.WebAPI.V1.Dtos
{
    public class StudentPatchDto
    {
        public int Id { get; set; }           
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }      
        public bool Active { get; set; }        
    }
}