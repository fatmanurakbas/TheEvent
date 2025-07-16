using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            var values = _contactRepository.GetAll();
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

            _contactRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var contact = _contactRepository.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _contactRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            var value = _contactRepository.GetById(id);
            if (value != null)
            {
                _contactRepository.Delete(value);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
