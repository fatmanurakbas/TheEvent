
using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TheEvent.ViewComponents
{
    public class _DefaultHotelComponentPartial : ViewComponent
    {
        //CafeContext Db=new CafeContext();

        private readonly TheEventContext _context;

        public _DefaultHotelComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        //constructor

        public IViewComponentResult Invoke()
        {
            //Eager Loading 
            var values = _context.Hotels.ToList();
            return View(values);
        }
    }
}