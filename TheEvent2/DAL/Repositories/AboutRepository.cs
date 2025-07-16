using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly TheEventContext _context;

        public AboutRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<About> GetAll()
        {
            return _context.Abouts.ToList();
        }

        public About GetById(int id)
        {
            return _context.Abouts.Find(id);
        }

        public void Add(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
        }

        public void Update(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
        }

        public void Delete(About about)
        {
            _context.Abouts.Remove(about);
            _context.SaveChanges();
        }
    }
}
