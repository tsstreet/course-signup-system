using DemoAPIApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.StudentServices
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentById(int id);

        Task<Student> AddStudent(Student student);

        Task<Student> UpdateStudent(int id, Student student);

        Task<Student> DeleteStudent(int id);

    }
}
