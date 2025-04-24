using Microsoft.AspNetCore.Mvc;

namespace YesilEvMVC.UI.Controllers
{
    public class HataController : Controller
    {
        public IActionResult ErisimYok()
        {
            ViewBag.Mesaj = "Bu işlem için yetkiniz bulunmamaktadır.";
            return View();
        }
    }
}
