using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TheEvent.DAL.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly TheEventContext _context;

        public VenueRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Venue> GetAll()
        {
            return _context.Venues.ToList();
        }

        public Venue? GetById(int id)
        {
            return _context.Venues.Find(id);
        }

        public void Add(Venue venue)
        {
            _context.Venues.Add(venue);
            _context.SaveChanges();
        }

        public void Update(Venue venue)
        {
            _context.Venues.Update(venue);
            _context.SaveChanges();
        }

        public void Delete(Venue venue)
        {
            _context.Venues.Remove(venue);
            _context.SaveChanges();
        }
    }
}
