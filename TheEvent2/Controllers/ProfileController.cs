using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IActionResult Index()
        {
            var profile = _profileRepository.GetFirstProfile(); // Giriş yapan kullanıcıya göre uyarlayabilirsin
            return View(profile);
        }

        [HttpGet]
        public IActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProfile(Profile model)
        {
            if (model.ImageFile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName));
                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl = "/images/" + Path.GetFileName(path);
            }

            _profileRepository.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            var profile = _profileRepository.GetById(id);
            return View(profile);
        }

        [HttpPost]
        public IActionResult UpdateProfile(Profile model)
        {
            if (model.ImageFile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName));
                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl = "/images/" + Path.GetFileName(path);
            }

            _profileRepository.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangePassword(int id)
        {
            var profile = _profileRepository.GetById(id);
            return View(profile);
        }

        [HttpPost]
        public IActionResult ChangePassword(Profile model)
        {
            var user = _profileRepository.GetById(model.ProfileId);
            if (user == null)
                return NotFound();

            if (user.Password != model.CurrentPasword)
            {
                ModelState.AddModelError("CurrentPasword", "Mevcut şifreniz yanlış.");
                return View(model);
            }

            if (model.NewPasword != model.ConfirmPasword)
            {
                ModelState.AddModelError("ConfirmPasword", "Yeni şifreler uyuşmuyor.");
                return View(model);
            }

            _profileRepository.ChangePassword(user.ProfileId, model.NewPasword);
            return RedirectToAction("Index");
        }
    }
}
