using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly IGalleryRepository _galleryRepository;

        public GalleryController(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public IActionResult Index()
        {
            var galleryList = _galleryRepository.GetAll();
            return View(galleryList);
        }

        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGallery(Gallery model)
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

            _galleryRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            var value = _galleryRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateGallery(Gallery model)
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

            _galleryRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGallery(int id)
        {
            var value = _galleryRepository.GetById(id);
            if (value != null)
            {
                _galleryRepository.Delete(value);
            }

            return RedirectToAction("Index");
        }
    }
}
