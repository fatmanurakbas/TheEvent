using Microsoft.AspNetCore.Mvc;

namespace TheEvent.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}


//Views Shared Components ismini Default