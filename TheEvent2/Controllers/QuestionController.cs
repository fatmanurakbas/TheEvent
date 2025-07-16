using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.Context;
using TheEvent.DAL.Entities;


namespace TheEvent.Controllers

{
    //[Authorize]
    //[Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly TheEventContext _context;

        public QuestionController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Questions.ToList();
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

            _context.Questions.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateQuestion(int id)
        {
            var adres = _context.Questions.Find(id);
            return View(adres);
        }

        [HttpPost]
        public IActionResult UpdateQuestion(Question model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Questions.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteQuestion(int id)
        {
            var value = _context.Questions.Find(id);
            if (value != null)
            {
                _context.Questions.Remove(value);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer bulunamazsa hata sayfası veya yönlendirme
            return NotFound(); // veya View("Error");
        }

    }
}
