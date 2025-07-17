
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TheEvent.ViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        private readonly TheEventContext _context;

        public _DefaultFooterComponentPartial(TheEventContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Sosyal medya linklerini çek
            var sosyalMedyaListesi = _context.SocialMedias.ToList();



            return View(sosyalMedyaListesi);
        }
    }

    // Footer için ViewModel (ViewComponent içinde tanımlı!)

}
