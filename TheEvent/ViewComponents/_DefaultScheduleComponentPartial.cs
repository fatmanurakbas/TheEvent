
using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TheEvent.ViewComponents
{
    public class _DefaultScheduleComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _DefaultScheduleComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Veritabanındaki tüm Gallery kayıtlarını çek
            var schedules = _context.Schedules.ToList();

            // View'a liste halinde gönder
            return View(schedules);
        }
    }
}
