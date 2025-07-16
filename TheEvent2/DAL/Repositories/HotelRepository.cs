using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TheEventContext _context;

        public HotelRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetById(int id)
        {
            return _context.Hotels.Find(id);
        }

        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        public void Delete(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }
    }
}
