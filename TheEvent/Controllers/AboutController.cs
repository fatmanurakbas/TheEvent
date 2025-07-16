using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheEvent.Controllers

{
    //[Authorize]
    // [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly TheEventContext _context;

        public AboutController(TheEventContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            //Eager Loading
            var values = _context.Abouts.ToList();
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
                //uygulamanın çalıştığı dizini al
                var currenDirectory = Directory.GetCurrentDirectory();

                //uygulamanın uzantısını al (jpg,png)
                var extension = Path.GetExtension(model.ImageFile.FileName);

                //benzersiz bir dosya adı oluştur
                var filename = Guid.NewGuid().ToString();

                //Kayıt edilecek Dosyanın yolu
                var saveLocation = Path.Combine(currenDirectory, "wwwroot/images", filename + extension);

                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);

                //dosyayaı fiziksel olarak sunucuya yazar
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + filename + extension;
            }

            _context.Abouts.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {


            var value = _context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About model)
        {
            if (model.ImageFile != null)
            {
                //uygulamanın çalıştığı dizini al
                var currenDirectory = Directory.GetCurrentDirectory();

                //uygulamanın uzantısını al (jpg,png)
                var extension = Path.GetExtension(model.ImageFile.FileName);

                //benzersiz bir dosya adı oluştur
                var filename = Guid.NewGuid().ToString();

                //Kayıt edilecek Dosyanın yolu
                var saveLocation = Path.Combine(currenDirectory, "wwwroot/images", filename + extension);

                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);

                //dosyayaı fiziksel olarak sunucuya yazar
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + filename + extension;
            }

            _context.Abouts.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value != null)
            {
                _context.Abouts.Remove(value);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer bulunamazsa hata sayfası veya yönlendirme
            return NotFound(); // veya View("Error");
        }

    }
}
