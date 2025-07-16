using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Interfaces
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();
        Question? GetById(int id);
        void Add(Question question);
        void Update(Question question);
        void Delete(Question question);
    }
}
