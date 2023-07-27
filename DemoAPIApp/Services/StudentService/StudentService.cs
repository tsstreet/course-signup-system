using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Services.StudentService
{
    public class StudentService: IStudentService
    {

        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return student;
        }

        public async Task<Student> AddStudent(Student student, int classId)
        {
            var existStudent = await _context.Students.FirstOrDefaultAsync(x => x.Email == student.Email );
            var @class = await _context.Classes.FindAsync(classId);

            if (existStudent != null)
            {
                throw new Exception("Email already exist");
            }

            if (@class != null)
            {
                var classStudent = new ClassStudent
                {
                    Student = student,
                    Class = @class
                };

                _context.ClassStudents.Add(classStudent);
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var studentUpdate = await _context.Students.FindAsync(id);
            studentUpdate.LastName = student.LastName;
            studentUpdate.FullName = student.FullName;
            studentUpdate.Email = student.Email;
            studentUpdate.Address = student.Address;
            studentUpdate.Phone = student.Phone;
            studentUpdate.Dob = student.Dob;
            studentUpdate.Gender = student.Gender;
            studentUpdate.ParentName = student.ParentName;
            studentUpdate.Password = student.Password;
            studentUpdate.ImageUrl = studentUpdate.ImageUrl;

            await _context.SaveChangesAsync();

            return studentUpdate;
        }

        public async Task<Student> DeleteStudent(int id)
        {

            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<ICollection<Class>> GetClassesByStudent(int studentId)
        {
            var classes = await _context.Students
                .Where(s => s.StdId == studentId)
                .SelectMany(s => s.ClassStudents)
                .Select(cs => cs.Class)
                .ToListAsync();

            return classes;
        }

        public async Task<bool> RegisterStudentForClass(int studentId, int classId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var @class = await _context.Classes.FindAsync(classId);

            var check = await _context.ClassStudents.FirstOrDefaultAsync(x => x.StudentId == studentId && x.ClassId == classId);

            if (student == null || @class == null)
            {
                return false;
            }
            else if (check != null)
            {
                return false;
            }
            var classStudent = new ClassStudent
            {
                StudentId = studentId,
                ClassId = classId
            };

            _context.ClassStudents.Add(classStudent);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UnregisterStudentFromClass(int studentId, int classId)
        {
            var classStudent = await _context.ClassStudents
                .FirstOrDefaultAsync(cs => cs.StudentId == studentId && cs.ClassId == classId);

            if (classStudent != null)
            {
                _context.ClassStudents.Remove(classStudent);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
