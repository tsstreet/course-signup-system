using DemoAPIApp.Data.Model;
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

        public async Task<Class> AddClass(Class classs)
        {
            var existClass = await _context.Classes.FirstOrDefaultAsync(x => x.ClassName == classs.ClassName );

            if (existClass != null)
            {
                throw new Exception("Class already exist");
            }


            _context.Classes.Add(classs);
            await _context.SaveChangesAsync();
            return classs;
        }

        public async Task<Class> UpdateClass(int id, Class classs)
        {
            var classUpdate = await _context.Classes.FindAsync(id);

            classUpdate.ClassName = classs.ClassName;
            classUpdate.NumOfStd = classs.NumOfStd;
            classUpdate.Active = classs.Active;
            classUpdate.Description = classs.Description;

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
    }
}
