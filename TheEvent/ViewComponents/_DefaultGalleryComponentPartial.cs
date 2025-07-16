using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultGalleryComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _DefaultGalleryComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Veritabanındaki tüm Gallery kayıtlarını çek
            var galleries = _context.Galleries.ToList();

            // View'a liste halinde gönder
            return View(galleries);
        }
    }
}
