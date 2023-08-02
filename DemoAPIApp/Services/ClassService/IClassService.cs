using DemoAPIApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.ClassService
{
    public interface IClassService
    {
        Task<List<Class>> GetClasses();

        Task<Class> GetClassById(int id);

        Task<Class> AddClass(Class request);

        Task<Class> UpdateClass(int id, Class request);

        Task<Class> DeleteClass(int id);

        Task<ICollection<Student>> GetStudentByClass(int classId);

        Task<ICollection<Subject>> GetSubjectByClass(int id);

        Task<ICollection<Schedule>> GetScheduleByClass(int id);

        Task<bool> RemoveSubjectFromClass(int classId, int subjectId);
    }
}

