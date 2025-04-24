namespace YesilEvMVC.UI.Models
{
    public class KullaniciAktivite
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int AktiviteId { get; set; }
        public Aktivite Aktivite { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
