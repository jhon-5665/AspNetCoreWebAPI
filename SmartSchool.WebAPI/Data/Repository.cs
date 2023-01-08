using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;        

        public Repository(SmartContext context)
        {            
            _context = context;
        } 

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }        

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(student => 
                student.Name.ToUpper().Contains(pageParams.Name.ToUpper()) || 
                student.Surname.ToUpper().Contains(pageParams.Name.ToUpper()));
            } 
           
            if (pageParams.Registration > 0)
            {
                query = query.Where(student => student.Registration == pageParams.Registration);
            }              
         
            if (pageParams.Active != null)
            {
                query = query.Where(student => student.Active == (pageParams.Active != 0));
            }                

            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return query.ToArray();
        }

        public async Task<Student[]> GetAllStudentsByDisciplineIdAsync(int disciplineId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(student => student.StudentsDisciplines.Any(sd => sd.DisciplineId == disciplineId));
            
            return await query.ToArrayAsync();
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(student => student.Id == studentId);
            
            return query.FirstOrDefault();
        }

        public Teacher[] GetAllTeachers(bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Disciplines).ThenInclude(sd => sd.StudentsDisciplines).ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking().OrderBy(t => t.Id);

            return query.ToArray();
        }

        public Teacher[] GetAllTeacherByDisciplineId(int disciplineId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Disciplines).ThenInclude(sd => sd.StudentsDisciplines).ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking().OrderBy(student => student.Id)
                         .Where(student => student.Disciplines
                         .Any(sd => sd.StudentsDisciplines.Any(d => d.DisciplineId == disciplineId)));

            return query.ToArray();
        }

        public Teacher GetTeacherById(int teacherId, bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(t => t.Disciplines).ThenInclude(sd => sd.StudentsDisciplines).ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(teacher => teacher.Id == teacherId);

            return query.FirstOrDefault();
        }

        public Teacher[] GetTeachersByStudentId(int studentId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Disciplines).ThenInclude(sd => sd.StudentsDisciplines).ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(student => student.Disciplines.Any(sd => 
                sd.StudentsDisciplines.Any(s => s.StudentId == studentId)));

            return query.ToArray();
        }
       
    }
}