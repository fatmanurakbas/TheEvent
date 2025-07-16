using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheEvent.DAL.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class ContactController : Controller
    {
        private readonly TheEventContext _context;

        public ContactController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Contacts.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var adres = _context.Contacts.Find(id);
            return View(adres);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Contacts.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value != null)
            {
                _context.Contacts.Remove(value);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer bulunamazsa hata sayfası veya yönlendirme
            return NotFound(); // veya View("Error");
        }

    }
}
