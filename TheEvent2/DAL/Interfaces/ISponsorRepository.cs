using TheEvent.DAL.Entities;
using System.Collections.Generic;

namespace TheEvent.DAL.Interfaces
{
    public interface ISponsorRepository
    {
        List<Sponsor> GetAll();
        Sponsor? GetById(int id);
        void Add(Sponsor sponsor);
        void Update(Sponsor sponsor);
        void Delete(Sponsor sponsor);
    }
}
