using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IFeatureRepository
    {
        List<Feature> GetAll();
        Feature GetById(int id);
        void Add(Feature feature);
        void Update(Feature feature);
        void Delete(Feature feature);
    }
}
