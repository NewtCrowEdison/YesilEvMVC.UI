using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace YesilEvMVC.UI.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult PremiumUyeOl()
        {
            return View();
        }

        public IActionResult EPostaDegistir()
        {
            return View();
        }

        public IActionResult SifreDegistir()
        {
            return View();
        }

        public IActionResult ProfilGuncelle()
        {
            return View();
        }

        public IActionResult Favoriler()
        {
            return View();
        }

        public IActionResult KaraListe()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Identity.Application");
            return RedirectToAction("Index", "Home");
        }
    }
}
