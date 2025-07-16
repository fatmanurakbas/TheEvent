using TheEvent.DAL.Entities;
using System.Collections.Generic;

namespace TheEvent.DAL.Interfaces
{
    public interface ISocialMediaRepository
    {
        List<SocialMedia> GetAll();
        SocialMedia? GetById(int id);
        void Add(SocialMedia socialMedia);
        void Update(SocialMedia socialMedia);
        void Delete(SocialMedia socialMedia);
    }
}
