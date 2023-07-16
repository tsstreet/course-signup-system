using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.FalcutyService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Services.FalcutyService
{
    public class FalcutyService: IFalcutyService
    {

        private readonly DataContext _context;

        public FalcutyService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Falcuty>> GetFalcuties()
        {
            return await _context.Falcuties.ToListAsync();
        }

        public async Task<Falcuty> GetFalcutyById(int id)
        {
            var falcuty = await _context.Falcuties.FindAsync(id);

            return falcuty;
        }

        public async Task<Falcuty> AddFalcuty(Falcuty falcuty)
        {
            var existFalcuty = await _context.Falcuties.FirstOrDefaultAsync(x => x.Name == falcuty.Name );

            if (existFalcuty != null)
            {
                throw new Exception("Falcuty already exist");
            }


            _context.Falcuties.Add(falcuty);
            await _context.SaveChangesAsync();
            return falcuty;
        }

        public async Task<Falcuty> UpdateFalcuty(int id, Falcuty falcuty)
        {
            var falcutyUpdate = await _context.Falcuties.FindAsync(id);

            falcutyUpdate.Name = falcuty.Name;
            await _context.SaveChangesAsync();

            return falcutyUpdate;
        }

        public async Task<Falcuty> DeleteFalcuty(int id)
        {

            var falcuty = await _context.Falcuties.FindAsync(id);

            _context.Falcuties.Remove(falcuty);

            await _context.SaveChangesAsync();

            return falcuty;
        }
    }
}
