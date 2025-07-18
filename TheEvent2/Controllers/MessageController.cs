using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IActionResult Index()
        {
            var messages = _messageRepository.GetAll();
            return View(messages);
        }

        public IActionResult DetailMessage(int id)
        {
            var message = _messageRepository.GetById(id);
            if (message != null && !message.IsRead)
            {
                message.IsRead = true;
                _messageRepository.Update(message);
            }
            return View(message);
        }

        public IActionResult DeleteMessage(int id)
        {
            var message = _messageRepository.GetById(id);
            if (message != null)
            {
                _messageRepository.Delete(message);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddMessage(Message message)
        {
            message.IsRead = false;
            message.SendDate = DateTime.Now;

            _messageRepository.Add(message);

            return Json(new { success = true });
        }


    }
}
