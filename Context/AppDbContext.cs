using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YesilEvMVC.UI.Models;

namespace YesilEvMVC.UI.Context
{
    public class AppDbContext : IdentityDbContext<Kullanici, AppRole, int>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aktivite> Aktivite { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<KayitTipi> KayitTipi { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<KullaniciAktivite> KullaniciAktivite { get; set; }
        public DbSet<KullaniciFavori> KullaniciFavori { get; set; }
        public DbSet<KullaniciKaraListe> KullaniciKaraListe { get; set; }
        public DbSet<ProgramIzin> ProgramIzin { get; set; }
        public DbSet<Uretici> Uretici { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunIcerik> UrunIcerik { get; set; }
        public DbSet<UrunIcerikRisk> UrunIcerikRisk { get; set; }
        public DbSet<UrunPaylas> UrunPaylas { get; set; }
        public DbSet<UrunPaylasKaydi> UrunPaylasKaydi { get; set; }
        public DbSet<UrunRiskRenk> UrunRiskRenk { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kullanici>()
                .HasOne<KayitTipi>()
                .WithMany(k => k.Kullanici)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KullaniciAktivite>()
                .HasOne(ka => ka.Kullanici)
                .WithMany(k => k.KullaniciVeAktivite)
                .HasForeignKey(ka => ka.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciAktivite>()
                .HasOne(ka => ka.Aktivite)
                .WithMany(a => a.KullaniciAktivite)
                .HasForeignKey(ka => ka.AktiviteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KullaniciKaraListe>()
                .HasOne(kk => kk.Kullanici)
                .WithMany(k => k.KullaniciVeKaraListe)
                .HasForeignKey(kk => kk.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciKaraListe>()
                .HasOne(kk => kk.UrunIcerik)
                .WithMany(ui => ui.KullaniciKaraListe)
                .HasForeignKey(kk => kk.UrunIcerikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProgramIzin>()
                .HasOne(pi => pi.Kullanici)
                .WithMany(k => k.ProgramIzin)
                .HasForeignKey(pi => pi.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Urun>()
                .HasOne(u => u.Kullanici)
                .WithMany(k => k.Urun)
                .HasForeignKey(u => u.KullaniciId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Urun>()
                .HasOne(u => u.Kategori)
                .WithMany(k => k.Urun)
                .HasForeignKey(u => u.KategoriId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Urun>()
                .HasOne(u => u.Uretici)
                .WithMany(ur => ur.Urun)
                .HasForeignKey(u => u.UreticiId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Urun>()
                .HasOne(u => u.UrunRiskRenk)
                .WithMany(rr => rr.Urun)
                .HasForeignKey(u => u.RenkId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UrunPaylas>()
                .HasMany(up => up.UrunPaylasKaydi)
                .WithOne(upk => upk.UrunPaylas)
                .HasForeignKey(upk => upk.PaylasmaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UrunPaylasKaydi>()
                .HasOne(upk => upk.Kullanici)
                .WithMany(k => k.UrunPaylasimKaydi)
                .HasForeignKey(upk => upk.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UrunPaylasKaydi>()
                .HasOne(upk => upk.Urun)
                .WithMany()
                .HasForeignKey(upk => upk.UrunId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UrunIcerikRisk>()
                .HasOne(uir => uir.Icerik)
                .WithMany(ui => ui.UrunIcerikRisk)
                .HasForeignKey(uir => uir.IcerikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UrunIcerikRisk>()
                .HasOne(uir => uir.UrunRisk)
                .WithMany(ur => ur.UrunIcerikRisk)
                .HasForeignKey(uir => uir.UrunRiskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KullaniciFavori>()
                .HasOne(kf => kf.Kullanici)
                .WithMany()
                .HasForeignKey(kf => kf.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciFavori>()
                .HasOne(kf => kf.Kategori)
                .WithMany()
                .HasForeignKey(kf => kf.KategoriId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KullaniciFavori>()
                .HasOne(kf => kf.Urun)
                .WithMany()
                .HasForeignKey(kf => kf.UrunId)
                .OnDelete(DeleteBehavior.Restrict);

            //Seed Data for Users
            // Seed KayitTipi
            modelBuilder.Entity<KayitTipi>().HasData(
                new KayitTipi { Id = 1, KayitAdi = "Gmail" },
                new KayitTipi { Id = 2, KayitAdi = "Hotmail" },
                new KayitTipi { Id = 3, KayitAdi = "Yahoo" },
                new KayitTipi { Id = 4, KayitAdi = "Outlook" }
            );

            var normalRole = new AppRole
            {
                Id = 1,
                Name = "Normal",
                NormalizedName = "NORMAL"
            };
            var premiumRole = new AppRole
            {
                Id = 2,
                Name = "Premium",
                NormalizedName = "PREMIUM"
            };
            var adminRole = new AppRole
            {
                Id = 3,
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            
            modelBuilder.Entity<AppRole>().HasData(
                normalRole,
                premiumRole,
                adminRole
            );
        }
    }
}
