using Microsoft.AspNetCore.Mvc;
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TheEvent.Controllers
{
    //[Authorize]
    //[Area("Admin")]
    public class SpeakerController : Controller
    {

        private readonly TheEventContext _context;

        public SpeakerController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Speakers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSpeaker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpeaker(Speaker model)
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


            _context.Speakers.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSpeaker(int id)
        {
            var value = _context.Speakers.Find(id);
            _context.Speakers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSpeaker(int id)
        {
            var value = _context.Speakers.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSpeaker(Speaker model)
        {
            var existingFeature = _context.Speakers.Find(model.SpeakerId);

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

            _context.Speakers.Update(existingFeature);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
