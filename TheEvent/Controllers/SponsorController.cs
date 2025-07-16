
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace TheEvent.Controllers

{
    //[Authorize]
    //[Area("Admin")]
    public class SponsorController : Controller
    {
        private readonly TheEventContext _context;

        public SponsorController(TheEventContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var galleryList = _context.Sponsors.ToList();
            return View(galleryList);
        }


        [HttpGet]
        public IActionResult AddSponsor()
        {


            return View();
        }

        [HttpPost]
        public IActionResult AddSponsor(Sponsor model)
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

            _context.Sponsors.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSponsor(int id)
        {

            var value = _context.Sponsors.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSponsor(Sponsor model)
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

            _context.Sponsors.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSponsor(int id)
        {
            var value = _context.Sponsors.Find(id);
            _context.Sponsors.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
