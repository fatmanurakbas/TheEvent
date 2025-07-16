using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly TheEventContext _context;

        public ProfileRepository(TheEventContext context)
        {
            _context = context;
        }

        public Profile? GetById(int id)
        {
            return _context.Profiles.Find(id);
        }

        public Profile? GetFirstProfile()
        {
            return _context.Profiles.FirstOrDefault(p => p.ProfileId == 1); // Örnek için
        }

        public void Add(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
            _context.SaveChanges();
        }

        public void ChangePassword(int profileId, string newPassword)
        {
            var user = _context.Profiles.Find(profileId);
            if (user != null)
            {
                user.Password = newPassword;
                _context.SaveChanges();
            }
        }
    }
}
