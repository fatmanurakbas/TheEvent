
using Microsoft.AspNetCore.Mvc;
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TheEvent.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class VenueController : Controller
    {

        private readonly TheEventContext _context;

        public VenueController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Venues.ToList();
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
            // ImageFile işlemi
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


            _context.Venues.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteVenue(int id)
        {
            var value = _context.Venues.Find(id);
            _context.Venues.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateVenue(int id)
        {
            var value = _context.Venues.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateVenue(Venue model)
        {
            var existingFeature = _context.Venues.Find(model.VenueId);

            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var ext = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(currentDir, "wwwroot/images", fileName + ext);
                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                existingFeature.ImageUrl = "/images/" + fileName + ext;
            }

            // Diğer alanlar için
            existingFeature.Title = model.Title;
            existingFeature.Description = model.Description;
           
            // ... varsa diğer alanlar

            _context.Venues.Update(existingFeature);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
