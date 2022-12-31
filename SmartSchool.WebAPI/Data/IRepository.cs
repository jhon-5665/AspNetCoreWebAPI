using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

        // Student
         Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeTeacher = false);
         Student[] GetAllStudents(bool includeTeacher = false);
         Student[] GetAllStudentsByDisciplineId(int disciplineId, bool includeTeacher = false);
         Student GetStudentById(int studentId, bool includeTeacher = false);

         // Teacher
         Teacher[] GetAllTeachers(bool includeStudents = false);
         Teacher[] GetAllTeacherByDisciplineId(int disciplineId, bool includeStudents = false);
         Teacher GetTeacherById(int teacherId, bool includeTeacher = false);          
    }
}