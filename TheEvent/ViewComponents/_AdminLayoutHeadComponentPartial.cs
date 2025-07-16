using Microsoft.AspNetCore.Mvc;

namespace TheEvent.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

//views-shared-component-_AdminLayoutHeadComponentPartial-Default
