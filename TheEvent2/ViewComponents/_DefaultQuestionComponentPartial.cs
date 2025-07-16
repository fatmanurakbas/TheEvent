
using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TheEvent.ViewComponents
{
    public class _DefaultQuestionComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _DefaultQuestionComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Veritabanındaki tüm Gallery kayıtlarını çek
            var questions = _context.Questions.ToList();

            // View'a liste halinde gönder
            return View(questions);
        }
    }
}
