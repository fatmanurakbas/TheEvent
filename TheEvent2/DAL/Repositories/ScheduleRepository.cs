using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TheEvent.DAL.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly TheEventContext _context;

        public ScheduleRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Schedule> GetAll()
        {
            return _context.Schedules.ToList();
        }

        public Schedule? GetById(int id)
        {
            return _context.Schedules.Find(id);
        }

        public void Add(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public void Update(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            _context.SaveChanges();
        }

        public void Delete(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
        }
    }
}
