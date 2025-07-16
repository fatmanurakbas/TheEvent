

using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TheEvent.ViewComponents
{
    public class _DefaultSponsorComponentPartial : ViewComponent
    {
        //CafeContext Db=new CafeContext();

        private readonly TheEventContext _context;

        public _DefaultSponsorComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        //constructor

        public IViewComponentResult Invoke()
        {
            //Eager Loading 
            var values = _context.Sponsors.ToList();
            return View(values);
        }
    }
}