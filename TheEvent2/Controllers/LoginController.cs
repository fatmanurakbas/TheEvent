
using TheEvent.Context;
using TheEvent.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace TheEvent.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly TheEventContext _context;

        public LoginController(TheEventContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Profile p)
        {
            // Kullanıcıyı veritabanından kontrol et
            var user = _context.Profiles.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            if (user != null)
            {
                // Giriş başarılı! Claims oluştur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.ProfileId.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Surname", user.SurName),
                    new Claim("ImageUrl", user.ImageUrl ?? ""),
                    new Claim("Email", user.Email ?? "")
                };

                // Identity ve Principal oluştur
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Kullanıcıyı oturum açtır
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Profil sayfasına yönlendir
                return RedirectToAction("Index", "Profile");
            }

            // Kullanıcı adı veya şifre hatalı!
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Çıkış işlemi
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
