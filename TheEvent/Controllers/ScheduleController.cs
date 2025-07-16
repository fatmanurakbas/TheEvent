using Microsoft.AspNetCore.Mvc;
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TheEvent.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class ScheduleController : Controller
    {

        private readonly TheEventContext _context;

        public ScheduleController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Schedules.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSchedule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSchedule(Schedule model)
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


            _context.Schedules.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSchedule(int id)
        {
            var value = _context.Schedules.Find(id);
            _context.Schedules.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSchedule(int id)
        {
            var value = _context.Schedules.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSchedule(Schedule model)
        {
            var existingFeature = _context.Schedules.Find(model.ScheduleId);

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
            existingFeature.Name = model.Name;
            existingFeature.Title = model.Title;
            existingFeature.Description = model.Description;
            existingFeature.Time = model.Time;

            // ... varsa diğer alanlar

            _context.Schedules.Update(existingFeature);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
