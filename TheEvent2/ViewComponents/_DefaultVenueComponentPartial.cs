

using TheEvent.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEvent.DAL.Entities;



namespace TheEvent.ViewComponents
{
    public class _DefaultVenueComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _DefaultVenueComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var venues = _context.Venues.ToList(); // Bu yeterli
           
            return View(venues);


            
        }
    }
}