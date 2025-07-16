using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public IActionResult Index()
        {
            var values = _aboutRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About model)
        {
            if (model.ImageFile != null)
            {
                var currenDirectory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var filename = Guid.NewGuid().ToString();
                var saveLocation = Path.Combine(currenDirectory, "wwwroot/images", filename + extension);
                var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl = "/images/" + filename + extension;
            }

            _aboutRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _aboutRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About model)
        {
            if (model.ImageFile != null)
            {
                var currenDirectory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var filename = Guid.NewGuid().ToString();
                var saveLocation = Path.Combine(currenDirectory, "wwwroot/images", filename + extension);
                var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl = "/images/" + filename + extension;
            }

            _aboutRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutRepository.GetById(id);
            if (value != null)
            {
                _aboutRepository.Delete(value);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
