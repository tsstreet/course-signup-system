using DemoAPIApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace DemoAPIApp.Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetSchedules();

        Task<Schedule> GetScheduleById(int id);

        Task<Schedule> AddSchedule(Schedule schedule);

        Task<Schedule> UpdateSchedule(int id, Schedule schedule);

        Task<Schedule> DeleteSchedule(int id);

    }
}
