using TheEvent.Context;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TheEventContext _context;

        public QuestionRepository(TheEventContext context)
        {
            _context = context;
        }

        public List<Question> GetAll()
        {
            return _context.Questions.ToList();
        }

        public Question? GetById(int id)
        {
            return _context.Questions.Find(id);
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(Question question)
        {
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }
    }
}
