

using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TheEvent.ViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _DefaultAboutComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Veritabanındaki tüm Gallery kayıtlarını çek
            var values = _context.Abouts.ToList();
            // context'i kullanarak veri çek
            return View();
        }
    }
}




