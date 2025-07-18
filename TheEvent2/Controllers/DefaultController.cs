using Microsoft.AspNetCore.Mvc;


namespace TheEvent.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
