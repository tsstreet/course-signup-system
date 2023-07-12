using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Data.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
