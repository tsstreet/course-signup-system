﻿using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.ClassService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Services.ClassService
{
    public class ClassService : IClassService
    {

        private readonly DataContext _context;

        public ClassService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            var classGet = await _context.Classes.FindAsync(id);

            return classGet;
        }

        public async Task<Class> AddClass(Class request)
        {
            //var academicYear = await _context.AcademicYears.Where(x => x.AcademicYearId == AcademicYearId).FirstOrDefaultAsync();
            //var department = await _context.Departments.Where(x => x.DepartmentId == DepartmentId).FirstOrDefaultAsync();

            var existClass = await _context.Classes.FirstOrDefaultAsync(x => x.ClassName == request.ClassName);

            if (existClass != null)
            {
                throw new Exception("Class already exist");
            }

            //var newClass = new Class
            //{
            //    ClassName = classDto.ClassName,
            //    AcademicYearId = classDto.AcademicYearId,
            //    DepartmentId = classDto.DepartmentId,
            //    Tuition = classDto.Tuition,
            //    NumOfStd = classDto.NumOfStd,
            //    Description = classDto.Description,
            //    ImageUrl = classDto.ImageUrl,
            //    Active = classDto.Active,
            //};

            _context.Classes.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Class> UpdateClass(int id, Class request)
        {
            var classUpdate = await _context.Classes.FindAsync(id);

            classUpdate.ClassName = request.ClassName;
            classUpdate.NumOfStd = request.NumOfStd;
            classUpdate.AcademicYearId = request.AcademicYearId;
            classUpdate.DepartmentId = request.DepartmentId;
            classUpdate.Active = request.Active;
            classUpdate.Description = request.Description;
            classUpdate.Tuition = request.Tuition;

            await _context.SaveChangesAsync();

            return classUpdate;
        }

        public async Task<Class> DeleteClass(int id)
        {

            var classDelete = await _context.Classes.FindAsync(id);

            _context.Classes.Remove(classDelete);

            await _context.SaveChangesAsync();

            return classDelete;
        }

        //public async Task<ICollection<Student>> GetStudentByClass(int classId)
        //{
        //    var students = await _context.ClassStudents.Where(x => x.ClassId == classId).Select(c => c.Student).ToListAsync();

        //    return students;
        //}
    }
}
