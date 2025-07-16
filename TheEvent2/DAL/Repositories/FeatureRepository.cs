using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly TheEventContext _context;

        public FeatureRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Feature> GetAll()
        {
            return _context.Features.ToList();
        }

        public Feature GetById(int id)
        {
            return _context.Features.Find(id);
        }

        public void Add(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
        }

        public void Update(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
        }

        public void Delete(Feature feature)
        {
            _context.Features.Remove(feature);
            _context.SaveChanges();
        }
    }
}
