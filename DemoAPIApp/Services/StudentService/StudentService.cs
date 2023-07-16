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

        public async Task<Student> AddStudent(Student student)
        {
            var existStudent = await _context.Students.FirstOrDefaultAsync(x => x.Email == student.Email );

            if (existStudent != null)
            {
                throw new Exception("Email already exist");
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
            //studentUpdate.Class = student.Class;
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
    }
}
