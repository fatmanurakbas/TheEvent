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

        public IActionResult Index()
        {
            var values = _ticketRepository.GetAll();
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

            _ticketRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTicket(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult UpdateTicket(Ticket model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _ticketRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTicket(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket != null)
            {
                _ticketRepository.Delete(ticket);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
