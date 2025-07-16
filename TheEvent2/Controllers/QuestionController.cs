using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public IActionResult Index()
        {
            var values = _questionRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(Question model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _questionRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateQuestion(int id)
        {
            var question = _questionRepository.GetById(id);
            return View(question);
        }

        [HttpPost]
        public IActionResult UpdateQuestion(Question model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _questionRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteQuestion(int id)
        {
            var value = _questionRepository.GetById(id);
            if (value != null)
            {
                _questionRepository.Delete(value);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
