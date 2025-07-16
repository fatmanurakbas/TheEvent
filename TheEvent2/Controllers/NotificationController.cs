using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IActionResult Index()
        {
            var values = _notificationRepository.GetAll();
            return View(values);
        }

        public IActionResult MakeRead(int id)
        {
            var notification = _notificationRepository.GetById(id);
            if (notification != null)
            {
                notification.IsRead = "true";
                _notificationRepository.Update(notification);
            }
            return RedirectToAction("Index");
        }

        public IActionResult MakeUnread(int id)
        {
            var notification = _notificationRepository.GetById(id);
            if (notification != null)
            {
                notification.IsRead = "false";
                _notificationRepository.Update(notification);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationRepository.GetById(id);
            if (value != null)
            {
                _notificationRepository.Delete(value);
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
            _notificationRepository.Add(model);
            return RedirectToAction("Index");
        }
    }
}
