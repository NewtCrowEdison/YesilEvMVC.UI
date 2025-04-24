using System.ComponentModel.DataAnnotations;

namespace YesilEvMVC.UI.Models
{
    public class Aktivite
    {
        public int Id { get; set; }
        public string AktiviteAdi { get; set; }
        public int? AktivitePuani { get; set; }
        public DateTime AktiviteZamani { get; set; }
        public ICollection<KullaniciAktivite> KullaniciAktivite { get; set; }
    }
}
