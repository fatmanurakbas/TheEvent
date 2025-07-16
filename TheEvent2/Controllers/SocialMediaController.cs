using Microsoft.AspNetCore.Mvc;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaController(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public IActionResult Index()
        {
            var list = _socialMediaRepository.GetAll();
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
            _socialMediaRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var item = _socialMediaRepository.GetById(id);
            if (item != null)
            {
                _socialMediaRepository.Delete(item);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var item = _socialMediaRepository.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia model)
        {
            _socialMediaRepository.Update(model);
            return RedirectToAction("Index");
        }
    }
}
