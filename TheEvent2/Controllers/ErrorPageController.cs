using Microsoft.AspNetCore.Mvc;

namespace TheEvent.Controllers
{
    public class ErrorPageController : Controller
    {
        [HttpGet]
        public IActionResult Page404()
        {


            return View();
        }
    }
}
