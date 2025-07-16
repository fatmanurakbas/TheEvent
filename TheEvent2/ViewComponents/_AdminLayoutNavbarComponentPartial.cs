using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TheEvent.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _AdminLayoutNavbarComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new NavbarViewModel
            {
                Notifications = _context.Notifications
                    .OrderByDescending(n => n.Time)
                    .Take(5)
                    .ToList(),

                UnreadMessages = _context.Messages
                    .Where(m => !m.IsRead)
                    .OrderByDescending(m => m.SendDate)
                    .Take(5)
                    .ToList(),

                UnreadMessageCount = _context.Messages.Count(m => !m.IsRead),
                UnreadNotificationCount = _context.Notifications.Count(n => n.IsRead == "false")
            };

            return View(viewModel);
        }
    }
}
