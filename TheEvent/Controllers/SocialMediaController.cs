using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheEvent.Context;
using TheEvent.DAL.Entities;

namespace TheEvent.Controllers

{
    //[Authorize]
    //[Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly TheEventContext _context;

        public SocialMediaController(TheEventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.SocialMedias.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia model)
        {
            _context.SocialMedias.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var item = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var item = _context.SocialMedias.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia model)
        {
            _context.SocialMedias.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
