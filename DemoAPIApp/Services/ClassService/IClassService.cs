﻿using DemoAPIApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.ClassService
{
    public interface IClassService
    {
        Task<List<Class>> GetClasses();

        Task<Class> GetClassById(int id);

        Task<Class> AddClass(Class request);

        Task<Class> UpdateClass(int id, Class classs);

        Task<Class> DeleteClass(int id);

        //Task<ICollection<Student>> GetStudentByClass(int classId);

    }
}
