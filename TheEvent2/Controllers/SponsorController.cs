using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class SponsorController : Controller
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorController(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public IActionResult Index()
        {
            var galleryList = _sponsorRepository.GetAll();
            return View(galleryList);
        }

        [HttpGet]
        public IActionResult AddSponsor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSponsor(Sponsor model)
        {
            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var filename = Guid.NewGuid().ToString();
                var saveLocation = Path.Combine(currentDir, "wwwroot/images", filename + extension);

                using var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + filename + extension;
            }

            _sponsorRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSponsor(int id)
        {
            var value = _sponsorRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSponsor(Sponsor model)
        {
            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var filename = Guid.NewGuid().ToString();
                var saveLocation = Path.Combine(currentDir, "wwwroot/images", filename + extension);

                using var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + filename + extension;
            }

            _sponsorRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSponsor(int id)
        {
            var value = _sponsorRepository.GetById(id);
            if (value != null)
            {
                _sponsorRepository.Delete(value);
            }
            return RedirectToAction("Index");
        }
    }
}
