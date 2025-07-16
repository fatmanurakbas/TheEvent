using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IActionResult Index()
        {
            var values = _hotelRepository.GetAll();
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

            _hotelRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHotel(int id)
        {
            var value = _hotelRepository.GetById(id);
            if (value != null)
            {
                _hotelRepository.Delete(value);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHotel(int id)
        {
            var value = _hotelRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateHotel(Hotel model)
        {
            var existingHotel = _hotelRepository.GetById(model.HotelId);

            if (existingHotel == null)
                return NotFound();

            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var ext = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(currentDir, "wwwroot/images", fileName + ext);
                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                existingHotel.ImageUrl = "/images/" + fileName + ext;
            }

            existingHotel.Title = model.Title;
            existingHotel.Description = model.Description;
            existingHotel.raiting = model.raiting;

            _hotelRepository.Update(existingHotel);
            return RedirectToAction("Index");
        }
    }
}
