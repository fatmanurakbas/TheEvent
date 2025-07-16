using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly TheEventContext _context;

        public GalleryRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Gallery> GetAll()
        {
            return _context.Galleries.ToList();
        }

        public Gallery GetById(int id)
        {
            return _context.Galleries.Find(id);
        }

        public void Add(Gallery gallery)
        {
            _context.Galleries.Add(gallery);
            _context.SaveChanges();
        }

        public void Update(Gallery gallery)
        {
            _context.Galleries.Update(gallery);
            _context.SaveChanges();
        }

        public void Delete(Gallery gallery)
        {
            _context.Galleries.Remove(gallery);
            _context.SaveChanges();
        }
    }
}
