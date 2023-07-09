
using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.StudentServices;
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

            await _context.SaveChangesAsync();

            return studentUpdate;
        }
    }
}
