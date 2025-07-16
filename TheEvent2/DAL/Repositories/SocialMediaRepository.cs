using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TheEvent.DAL.Repositories
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly TheEventContext _context;

        public SocialMediaRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<SocialMedia> GetAll()
        {
            return _context.SocialMedias.ToList();
        }

        public SocialMedia? GetById(int id)
        {
            return _context.SocialMedias.Find(id);
        }

        public void Add(SocialMedia socialMedia)
        {
            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
        }

        public void Update(SocialMedia socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
            _context.SaveChanges();
        }

        public void Delete(SocialMedia socialMedia)
        {
            _context.SocialMedias.Remove(socialMedia);
            _context.SaveChanges();
        }
    }
}
