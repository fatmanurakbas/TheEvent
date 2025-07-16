using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IGalleryRepository
    {
        List<Gallery> GetAll();
        Gallery GetById(int id);
        void Add(Gallery gallery);
        void Update(Gallery gallery);
        void Delete(Gallery gallery);
    }
}
