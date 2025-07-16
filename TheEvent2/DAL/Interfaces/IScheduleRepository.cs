using TheEvent.DAL.Entities;
using System.Collections.Generic;

namespace TheEvent.DAL.Interfaces
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAll();
        Schedule? GetById(int id);
        void Add(Schedule schedule);
        void Update(Schedule schedule);
        void Delete(Schedule schedule);
    }
}
