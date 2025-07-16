using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TheEvent.DAL.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly TheEventContext _context;

        public SponsorRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Sponsor> GetAll()
        {
            return _context.Sponsors.ToList();
        }

        public Sponsor? GetById(int id)
        {
            return _context.Sponsors.Find(id);
        }

        public void Add(Sponsor sponsor)
        {
            _context.Sponsors.Add(sponsor);
            _context.SaveChanges();
        }

        public void Update(Sponsor sponsor)
        {
            _context.Sponsors.Update(sponsor);
            _context.SaveChanges();
        }

        public void Delete(Sponsor sponsor)
        {
            _context.Sponsors.Remove(sponsor);
            _context.SaveChanges();
        }
    }
}
