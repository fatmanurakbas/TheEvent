using TheEvent.DAL.Entities;
using System.Collections.Generic;

namespace TheEvent.DAL.Interfaces
{
    public interface IVenueRepository
    {
        List<Venue> GetAll();
        Venue? GetById(int id);
        void Add(Venue venue);
        void Update(Venue venue);
        void Delete(Venue venue);
    }
}
