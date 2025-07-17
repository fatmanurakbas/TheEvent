using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // Tüm biletleri listele
        public IActionResult Index()
        {
            var tickets = _ticketRepository.GetAll();
            return View(tickets);
        }

        // Yeni bilet ekleme sayfası (GET)
        [HttpGet]
        public IActionResult AddTicket()
        {
            return View();
        }

        // Yeni bilet ekleme işlemi (POST)
        [HttpPost]
        public IActionResult AddTicket(Ticket model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _ticketRepository.Add(model);
            return RedirectToAction(nameof(Index));
        }

        // Bilet güncelleme sayfası (GET)
        [HttpGet]
        public IActionResult UpdateTicket(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // Bilet güncelleme işlemi (POST)
        [HttpPost]
        public IActionResult UpdateTicket(Ticket model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _ticketRepository.Update(model);
            return RedirectToAction(nameof(Index));
        }

        // Bilet silme işlemi
        public IActionResult DeleteTicket(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _ticketRepository.Delete(ticket);
            return RedirectToAction(nameof(Index));
        }
    }
}
