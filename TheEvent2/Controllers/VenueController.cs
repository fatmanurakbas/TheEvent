using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class VenueController : Controller
    {
        private readonly IVenueRepository _venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public IActionResult Index()
        {
            var values = _venueRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddVenue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVenue(Venue model)
        {
            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var ext = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(currentDir, "wwwroot/images", fileName + ext);

                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + fileName + ext;
            }

            _venueRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteVenue(int id)
        {
            var value = _venueRepository.GetById(id);
            if (value != null)
            {
                _venueRepository.Delete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateVenue(int id)
        {
            var value = _venueRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateVenue(Venue model)
        {
            var existingVenue = _venueRepository.GetById(model.VenueId);

            if (existingVenue == null)
                return NotFound();

            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var ext = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(currentDir, "wwwroot/images", fileName + ext);

                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                existingVenue.ImageUrl = "/images/" + fileName + ext;
            }

            existingVenue.Title = model.Title;
            existingVenue.Description = model.Description;
            // Diğer alanlar varsa onları da ekleyebilirsiniz.

            _venueRepository.Update(existingVenue);

            return RedirectToAction("Index");
        }
    }
}
