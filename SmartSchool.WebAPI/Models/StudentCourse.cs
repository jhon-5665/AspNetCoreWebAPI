namespace SmartSchool.WebAPI.Models
{
    public class StudentCourse
    {
        public StudentCourse() { }
        public StudentCourse(int studentId, int courseId)
        {
            this.StudentId = studentId;            
            this.CourseId = courseId;          
        }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } 
        public int? Note { get; set; } = null;
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}