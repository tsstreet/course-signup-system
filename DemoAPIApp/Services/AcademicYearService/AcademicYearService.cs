using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.AcademicYearService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Services.FalcutyService
{
    public class AcademicYearService : IAcademicYearService
    {

        private readonly DataContext _context;

        public AcademicYearService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<AcademicYear>> GetAcademicYears()
        {
            return await _context.AcademicYears.ToListAsync();
        }

        public async Task<AcademicYear> GetAcademicYearById(int id)
        {
            var academicYear = await _context.AcademicYears.FindAsync(id);

            return academicYear;
        }

        public async Task<AcademicYear> AddAcademicYear(AcademicYear academicYear)
        {
            var existAcademicYear = await _context.AcademicYears.FirstOrDefaultAsync(x => x.Name == academicYear.Name );

            if (existAcademicYear != null)
            {
                throw new Exception("Academic Year already exist");
            }


            _context.AcademicYears.Add(academicYear);
            await _context.SaveChangesAsync();
            return academicYear;
        }

        public async Task<AcademicYear> UpdateAcademicYear(int id, AcademicYear academicYear)
        {
            var academicYearUpdate = await _context.AcademicYears.FindAsync(id);

            academicYearUpdate.Name = academicYear.Name;
            await _context.SaveChangesAsync();

            return academicYearUpdate;
        }

        public async Task<AcademicYear> DeleteAcademicYear(int id)
        {

            var academicYear = await _context.AcademicYears.FindAsync(id);

            _context.AcademicYears.Remove(academicYear);

            await _context.SaveChangesAsync();

            return academicYear;
        }

        public async Task<ICollection<Class>> GetClassByAcademicYear(int id)
        {
            var classGet = await _context.AcademicYears.Where(x => x.AcademicYearId == id).Select(c => c.Classes).FirstOrDefaultAsync();

            return classGet.ToList();
        }
    }
}
