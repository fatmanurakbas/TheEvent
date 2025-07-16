using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.Context;


namespace TheEvent.Controllers
{
    [Authorize]
    //[Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly TheEventContext _context;

        public ProfileController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Giriş yapan kullanıcının profilini al – örnek olarak Id=1
            var profile = _context.Profiles.FirstOrDefault(p => p.ProfileId == 1);
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

            _context.Profiles.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            var profile = _context.Profiles.Find(id);
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

            _context.Profiles.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangePassword(int id)
        {
            var profile = _context.Profiles.Find(id);
            return View(profile);
        }

        [HttpPost]
        public IActionResult ChangePassword(Profile model)
        {
            var user = _context.Profiles.Find(model.ProfileId);
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

            user.Password = model.NewPasword;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
