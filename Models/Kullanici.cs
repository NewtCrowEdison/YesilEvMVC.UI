using Microsoft.AspNetCore.Identity;

namespace YesilEvMVC.UI.Models
{
    public class Kullanici : IdentityUser<int>
    {
        public ICollection<KullaniciAktivite> KullaniciVeAktivite { get; set; } = new List<KullaniciAktivite>();
        public ICollection<KullaniciKaraListe> KullaniciVeKaraListe { get; set; } = new List<KullaniciKaraListe>();
        public ICollection<ProgramIzin> ProgramIzin { get; set; } = new List<ProgramIzin>();
        public ICollection<Urun> Urun { get; set; } = new List<Urun>();
        public ICollection<UrunPaylasKaydi> UrunPaylasimKaydi { get; set; } = new List<UrunPaylasKaydi>();
    }
}
