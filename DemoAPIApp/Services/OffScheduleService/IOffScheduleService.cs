using DemoAPIApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.OffScheduleService
{
    public interface IOffScheduleService
    {
        Task<List<OffSchedule>> GetOffSchedules();

        Task<OffSchedule> GetOffScheduleById(int id);

        Task<OffSchedule> AddOffSchedule(OffSchedule offSchedule);

        Task<OffSchedule> UpdateOffSchedule(int id, OffSchedule offSchedule);

        Task<OffSchedule> DeleteOffSchedule(int id);

        Task<List<OffSchedule>> Search(string searchString);
    }
}
