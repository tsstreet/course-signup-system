﻿using DemoAPIApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachers();

        Task<Teacher> GetTeacherById(int id);

        Task<Teacher> AddTeacher(Teacher teacher);

        Task<Teacher> UpdateTeacher(int id, Teacher teacher);

        Task<Teacher> DeleteTeacher(int id);

    }
}
