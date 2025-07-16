using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
        Hotel GetById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(Hotel hotel);
    }
}
