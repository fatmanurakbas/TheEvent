using TheEvent.DAL.Entities;
using System.Collections.Generic;

namespace TheEvent.DAL.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket? GetById(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
    }
}
