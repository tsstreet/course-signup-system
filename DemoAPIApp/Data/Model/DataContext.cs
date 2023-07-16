using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Data.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }    

        public DbSet<User> Users { get; set; }

        public DbSet<Assign> Assigns { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Falcuty> Falcuties { get; set; }
        public DbSet<Subject> Subjects { get; set; } 
    }
}
