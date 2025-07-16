using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface INotificationRepository
    {
        List<Notification> GetAll();
        Notification GetById(int id);
        void Add(Notification notification);
        void Update(Notification notification);
        void Delete(Notification notification);
    }
}
