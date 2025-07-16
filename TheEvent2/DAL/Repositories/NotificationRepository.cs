using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TheEventContext _context;

        public NotificationRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Notification> GetAll()
        {
            return _context.Notifications.OrderByDescending(n => n.Time).ToList();
        }

        public Notification GetById(int id)
        {
            return _context.Notifications.Find(id);
        }

        public void Add(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void Update(Notification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();
        }

        public void Delete(Notification notification)
        {
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
        }
    }
}
