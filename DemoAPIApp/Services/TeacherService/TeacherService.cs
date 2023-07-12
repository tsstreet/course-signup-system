using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.StudentServices;
using DemoAPIApp.Services.TeacherServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Services.TeacherService
{
    public class TeacherService: ITeacherService
    {

        private readonly DataContext _context;

        public TeacherService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            return teacher;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
        {
            var teacherUpdate = await _context.Teachers.FindAsync(id);
            teacherUpdate.LastName = teacher.LastName;
            teacherUpdate.FullName = teacher.FullName;
            teacherUpdate.Email = teacher.Email;
            teacherUpdate.Address = teacher.Address;
            teacherUpdate.Phone = teacher.Phone;
            teacherUpdate.BirthDay = teacher.BirthDay;
            teacherUpdate.Gender = teacher.Gender;
            teacherUpdate.Password = teacher.Password;
            teacherUpdate.ImageUrl = teacher.ImageUrl;

            await _context.SaveChangesAsync();

            return teacherUpdate;
        }

        public async Task<Teacher> DeleteTeacher(int id)
        {

            var teacher = await _context.Teachers.FindAsync(id);

            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();

            return teacher;
        }

    }
}
