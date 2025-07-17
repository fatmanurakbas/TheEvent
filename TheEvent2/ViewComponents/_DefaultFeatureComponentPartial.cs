
using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TheEvent.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        //TheEventContext Db=new TheEventContext();

        private readonly TheEventContext _context;

        public _DefaultFeatureComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        //constructor

        public IViewComponentResult Invoke()
        {
            var feature = _context.Features.FirstOrDefault();
            if (feature != null)
            {
                ViewBag.Subtitle = feature.SubTitle;
                ViewBag.Title = feature.Title;
                ViewBag.ImageUrl = feature.ImageUrl;
               
            }
            return View();
        }
    }
}