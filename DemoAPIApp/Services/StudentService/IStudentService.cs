using DemoAPIApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentById(int id);

        Task<Student> AddStudent(Student student, int classId);

        Task<Student> UpdateStudent(int id, Student student);

        Task<Student> DeleteStudent(int id);

        Task<ICollection<Class>> GetClassesByStudent(int studentId);

        Task<bool> RegisterStudentForClass(int studentId, int classId);

        Task<bool> UnregisterStudentFromClass(int studentId, int classId);
    }
}
