using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TheEventContext _context;

        public MessageRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Message> GetAll()
        {
            return _context.Messages.OrderByDescending(x => x.SendDate).ToList();
        }

        public Message GetById(int id)
        {
            return _context.Messages.Find(id);
        }

        public void Add(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Update(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
        }

        public void Delete(Message message)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }
    }
}
