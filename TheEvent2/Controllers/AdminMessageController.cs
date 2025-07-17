using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        public AdminMessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        // ✨ Buraya yazmalısın:
        public IActionResult Index()
        {
            var messages = _messageRepository.GetAll();
            return View(messages);
        }
    }
}
