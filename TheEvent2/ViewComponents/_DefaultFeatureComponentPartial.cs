
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
            //Eager Loading 
            var values = _context.Features.ToList();
            return View(values);
        }
    }
}