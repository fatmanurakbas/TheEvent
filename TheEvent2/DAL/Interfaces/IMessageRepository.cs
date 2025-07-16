using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
