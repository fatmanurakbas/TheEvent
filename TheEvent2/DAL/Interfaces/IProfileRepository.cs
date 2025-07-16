using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IProfileRepository
    {
        Profile? GetById(int id);
        Profile? GetFirstProfile(); // Index için örnek amaçlı
        void Add(Profile profile);
        void Update(Profile profile);
        void ChangePassword(int profileId, string newPassword);
    }
}
