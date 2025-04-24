using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YesilEvMVC.UI.Context;
using YesilEvMVC.UI.Models;
using YesilEvMVC.UI.ViewModels;

namespace YesilEvMVC.UI.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<Kullanici> _userManager;

        public UrunController(AppDbContext context, IWebHostEnvironment env, UserManager<Kullanici> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var urunler = await _context.Urun.Include(u => u.Kategori)
                                             .Include(u => u.Uretici)
                                             .Include(u => u.UrunRiskRenk)
                                             .ToListAsync();

            ViewBag.IsAdmin = User.IsInRole("Admin");

            return View(urunler);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Arama(string query)
        {
            if (string.IsNullOrEmpty(query))
                return View(new List<Urun>());

            var sonuc = await _context.Urun
                .Include(u => u.Kategori)
                .Where(u => u.UrunAdi.Contains(query) || u.BarkodNo.ToString().Contains(query))
                .ToListAsync();

            return View(sonuc);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detay(int id)
        {
            var urun = await _context.Urun
            .Include(u => u.Kategori)
            .Include(u => u.Uretici)
            .Include(u => u.UrunRiskRenk)
            .Include(u => u.UrunIcerik)
            .FirstOrDefaultAsync(u => u.Id == id);

            if (urun == null)
                return NotFound();

            return View(urun);
        }

        private async Task<string> ResimKaydetAsync(IFormFile resim)
        {
            var wwwRootPath = _env.WebRootPath;
            var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(resim.FileName);
            var yol = Path.Combine(wwwRootPath, "img", dosyaAdi);

            using (var stream = new FileStream(yol, FileMode.Create))
            {
                await resim.CopyToAsync(stream);
            }

            return "/img/" + dosyaAdi;
        }

        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = _context.Kategori.ToList();
            ViewBag.Ureticiler = _context.Uretici.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.KullaniciId = KullaniciIdGetir();

                if (urun.OnYuzResmi != null)
                    urun.OnYuzResmiYolu = await ResimKaydetAsync(urun.OnYuzResmi);

                if (urun.ArkaYuzResmi != null)
                    urun.ArkaYuzResmiYolu = await ResimKaydetAsync(urun.ArkaYuzResmi);

                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Kategoriler = _context.Kategori.ToList();
            ViewBag.Ureticiler = _context.Uretici.ToList();
            return View(urun);
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            var urun = await _context.Urun.FindAsync(id);
            if (urun == null) return NotFound();

            var vm = new UrunVM
            {
                Id = urun.Id,
                UrunAdi = urun.UrunAdi,
                BarkodNo = urun.BarkodNo,
                KategoriId = urun.KategoriId,
                UreticiId = urun.UreticiId
            };

            ViewBag.Kategoriler = _context.Kategori.ToList();
            ViewBag.Ureticiler = _context.Uretici.ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, UrunVM model)
        {
            if (id != model.Id) return NotFound();

            var urun = await _context.Urun.FindAsync(id);
            if (urun == null) return NotFound();

            if (ModelState.IsValid)
            {
                urun.UrunAdi = model.UrunAdi;
                urun.BarkodNo = model.BarkodNo;
                urun.KategoriId = model.KategoriId;
                urun.UreticiId = model.UreticiId;

                if (model.OnYuzResmi != null)
                {
                    urun.OnYuzResmiYolu = await ResimKaydetAsync(model.OnYuzResmi);
                }

                if (model.ArkaYuzResmi != null)
                {
                    urun.ArkaYuzResmiYolu = await ResimKaydetAsync(model.ArkaYuzResmi);
                }

                _context.Update(urun);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Kategoriler = _context.Kategori.ToList();
            ViewBag.Ureticiler = _context.Uretici.ToList();
            return View(model);
        }

        public async Task<IActionResult> Sil(int id)
        {
            var urun = await _context.Urun.FindAsync(id);
            if (urun != null)
            {
                _context.Urun.Remove(urun);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Favoriler()
        {
            var userId = _userManager.GetUserId(User);
            int parsedId = int.Parse(userId);
            var favoriler = _context.KullaniciFavori
                            .Include(f => f.Urun)
                            .Where(f => f.KullaniciId == parsedId)
                            .ToList();
            return View(favoriler);
        }
        [Authorize]
        public async Task<IActionResult> KaraListe()
        {
            var userId = _userManager.GetUserId(User);
            int parsedId = int.Parse(userId);
            var karaListe = _context.KullaniciKaraListe
                                    .Include(k => k.UrunIcerik)
                                    .Where(k => k.KullaniciId == parsedId)
                                    .ToList();
            return View(karaListe);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> KaraListeyeEkle(int icerikId)
        {
            var userId = int.Parse(_userManager.GetUserId(User));

            // Aynı içerik daha önce eklenmiş mi kontrolü
            var mevcut = _context.KullaniciKaraListe
                .FirstOrDefault(k => k.KullaniciId == userId && k.UrunIcerikId == icerikId);

            if (mevcut == null)
            {
                _context.KullaniciKaraListe.Add(new KullaniciKaraListe
                {
                    KullaniciId = userId,
                    UrunIcerikId = icerikId
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("IcerikListesi");
        }
        [Authorize]
        public IActionResult IcerikListesi()
        {
            var icerikler = _context.UrunIcerik.ToList();
            return View(icerikler);
        }

        private int KullaniciIdGetir()
        {
            return int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
        }
    }
}
