using Microsoft.AspNetCore.Mvc;
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TheEvent.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class HotelController : Controller
    {

        private readonly TheEventContext _context;

        public HotelController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Hotels.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHotel(Hotel model)
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


            _context.Hotels.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHotel(int id)
        {
            var value = _context.Hotels.Find(id);
            _context.Hotels.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHotel(int id)
        {
            var value = _context.Hotels.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateHotel(Hotel model)
        {
            var existingFeature = _context.Hotels.Find(model.HotelId);

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
            existingFeature.raiting = model.raiting;

            // ... varsa diğer alanlar

            _context.Hotels.Update(existingFeature);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
