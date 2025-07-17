

using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TheEvent.ViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        

        private readonly TheEventContext _context;

        public _DefaultContactComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        //constructor

        public IViewComponentResult Invoke()
        {
            //Eager Loading 
            var values = _context.Contacts.ToList();
            return View(values);
        }
    }
}