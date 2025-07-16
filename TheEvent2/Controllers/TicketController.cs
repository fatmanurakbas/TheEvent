
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheEvent.DAL.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class TicketController : Controller
    {
        private readonly TheEventContext _context;

        public TicketController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Tickets.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTicket()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTicket(Ticket model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Tickets.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTicket(int id)
        {
            var adres = _context.Tickets.Find(id);
            return View(adres);
        }

        [HttpPost]
        public IActionResult UpdateTicket(Ticket model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Tickets.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTicket(int id)
        {
            var value = _context.Tickets.Find(id);
            if (value != null)
            {
                _context.Tickets.Remove(value);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer bulunamazsa hata sayfası veya yönlendirme
            return NotFound(); // veya View("Error");
        }

    }
}
