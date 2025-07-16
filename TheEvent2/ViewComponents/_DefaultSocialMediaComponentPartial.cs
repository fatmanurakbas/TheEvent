


using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TheEvent.ViewComponents
{
    public class _DefaultSocialMediaComponentPartial : ViewComponent
    {
        //CafeContext Db=new CafeContext();

        private readonly TheEventContext _context;

        public _DefaultSocialMediaComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        //constructor

        public IViewComponentResult Invoke()
        {
            //Eager Loading 
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
    }
}