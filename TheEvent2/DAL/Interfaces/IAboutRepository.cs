using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IAboutRepository
    {
        List<About> GetAll();
        About GetById(int id);
        void Add(About about);
        void Update(About about);
        void Delete(About about);
    }
}
