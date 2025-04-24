using Microsoft.AspNetCore.Mvc;
using YesilEvMVC.UI.Context;
using YesilEvMVC.UI.Models;
using YesilEvMVC.UI.ViewModels;

namespace YesilEvMVC.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // Kategori CRUD
        public IActionResult KategoriListe()
        {
            var kategoriler = _context.Kategori
                .Select(k => new KategoriVM
                {
                    Id = k.Id,
                    KategoriAdi = k.KategoriAdi
                }).ToList();

            return View(kategoriler);
        }
        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(KategoriVM model)
        {
            if (ModelState.IsValid)
            {
                var kategori = new Kategori { KategoriAdi = model.KategoriAdi };
                _context.Kategori.Add(kategori);
                _context.SaveChanges();
                return RedirectToAction("KategoriListe");
            }
            return View(model);
        }

        public IActionResult KategoriDuzenle(int id)
        {
            var kategori = _context.Kategori.Find(id);
            if (kategori == null) return NotFound();

            var viewModel = new KategoriVM
            {
                Id = kategori.Id,
                KategoriAdi = kategori.KategoriAdi
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult KategoriDuzenle(KategoriVM model)
        {
            if (ModelState.IsValid)
            {
                var kategori = _context.Kategori.Find(model.Id);
                if (kategori == null) return NotFound();

                kategori.KategoriAdi = model.KategoriAdi;
                _context.SaveChanges();
                return RedirectToAction("KategoriListe");
            }
            return View(model);
        }

        public IActionResult KategoriSil(int id)
        {
            var kategori = _context.Kategori.Find(id);
            if (kategori == null) return NotFound();

            _context.Kategori.Remove(kategori);
            _context.SaveChanges();
            return RedirectToAction("KategoriListe");
        }


        // Uretici CRUD
        public IActionResult UreticiListe()
        {
            var ureticiler = _context.Uretici
                .Select(u => new UreticiVM
                {
                    Id = u.Id,
                    UreticiAdi = u.UreticiAdi
                }).ToList();

            return View(ureticiler);
        }
        public IActionResult UreticiEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UreticiEkle(UreticiVM model)
        {
            if (ModelState.IsValid)
            {
                var uretici = new Uretici { UreticiAdi = model.UreticiAdi };
                _context.Uretici.Add(uretici);
                _context.SaveChanges();
                return RedirectToAction("UreticiListe");
            }
            return View(model);
        }

        public IActionResult UreticiDuzenle(int id)
        {
            var uretici = _context.Uretici.Find(id);
            if (uretici == null) return NotFound();

            var viewModel = new UreticiVM
            {
                Id = uretici.Id,
                UreticiAdi = uretici.UreticiAdi
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UreticiDuzenle(UreticiVM model)
        {
            if (ModelState.IsValid)
            {
                var uretici = _context.Uretici.Find(model.Id);
                if (uretici == null) return NotFound();

                uretici.UreticiAdi = model.UreticiAdi;
                _context.SaveChanges();
                return RedirectToAction("UreticiListe");
            }
            return View(model);
        }

        public IActionResult UreticiSil(int id)
        {
            var uretici = _context.Uretici.Find(id);
            if (uretici == null) return NotFound();

            _context.Uretici.Remove(uretici);
            _context.SaveChanges();
            return RedirectToAction("UreticiListe");
        }


        // Aktivite CRUD
        public IActionResult AktiviteListe()
        {
            var aktiviteler = _context.Aktivite
                .Select(a => new AktiviteVM
                {
                    Id = a.Id,
                    AktiviteAdi = a.AktiviteAdi,
                    AktivitePuani = a.AktivitePuani,
                    AktiviteZamani = a.AktiviteZamani
                }).ToList();

            return View(aktiviteler);
        }
        public IActionResult AktiviteEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AktiviteEkle(AktiviteVM model)
        {
            if (ModelState.IsValid)
            {
                var aktivite = new Aktivite
                {
                    AktiviteAdi = model.AktiviteAdi,
                    AktivitePuani = model.AktivitePuani,
                    AktiviteZamani = model.AktiviteZamani
                };
                _context.Aktivite.Add(aktivite);
                _context.SaveChanges();
                return RedirectToAction("AktiviteListe");
            }
            return View(model);
        }

        public IActionResult AktiviteDuzenle(int id)
        {
            var aktivite = _context.Aktivite.Find(id);
            if (aktivite == null) return NotFound();

            var viewModel = new AktiviteVM
            {
                Id = aktivite.Id,
                AktiviteAdi = aktivite.AktiviteAdi,
                AktivitePuani = aktivite.AktivitePuani,
                AktiviteZamani = aktivite.AktiviteZamani
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AktiviteDuzenle(AktiviteVM model)
        {
            if (ModelState.IsValid)
            {
                var aktivite = _context.Aktivite.Find(model.Id);
                if (aktivite == null) return NotFound();

                aktivite.AktiviteAdi = model.AktiviteAdi;
                aktivite.AktivitePuani = model.AktivitePuani;
                aktivite.AktiviteZamani = model.AktiviteZamani;
                _context.SaveChanges();
                return RedirectToAction("AktiviteListe");
            }
            return View(model);
        }

        public IActionResult AktiviteSil(int id)
        {
            var aktivite = _context.Aktivite.Find(id);
            if (aktivite == null) return NotFound();

            _context.Aktivite.Remove(aktivite);
            _context.SaveChanges();
            return RedirectToAction("AktiviteListe");
        }
    }
}
