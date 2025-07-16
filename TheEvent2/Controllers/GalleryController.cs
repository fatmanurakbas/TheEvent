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
    public class GalleryController : Controller
    {
        private readonly TheEventContext _context;

        public GalleryController(TheEventContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var galleryList = _context.Galleries.ToList();
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

            _context.Galleries.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {

            var value = _context.Galleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateGallery(Gallery model)
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

            _context.Galleries.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            _context.Galleries.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
