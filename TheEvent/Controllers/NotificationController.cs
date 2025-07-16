using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.Context;


namespace TheEvent.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly TheEventContext _context;

        public NotificationController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Notifications.OrderByDescending(n => n.Time).ToList();
            return View(values);
        }

        public IActionResult MakeRead(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                notification.IsRead = "true";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult MakeUnread(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                notification.IsRead = "false";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value != null)
            {
                _context.Notifications.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotification(Notification model)
        {
            model.Time = DateTime.Now;
            model.IsRead = "false";
            _context.Notifications.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
