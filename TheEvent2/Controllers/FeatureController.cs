using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public IActionResult Index()
        {
            var values = _featureRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(Feature model)
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

            _featureRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFeature(int id)
        {
            var value = _featureRepository.GetById(id);
            if (value != null)
            {
                _featureRepository.Delete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var value = _featureRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateFeature(Feature model)
        {
            var existingFeature = _featureRepository.GetById(model.FeatureId);

            if (existingFeature == null)
                return NotFound();

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

            existingFeature.Title = model.Title;
            existingFeature.SubTitle = model.SubTitle;

            _featureRepository.Update(existingFeature);
            return RedirectToAction("Index");
        }
    }
}
