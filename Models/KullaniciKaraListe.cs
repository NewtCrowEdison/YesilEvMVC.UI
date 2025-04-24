namespace YesilEvMVC.UI.Models
{
    public class KullaniciKaraListe
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int UrunIcerikId { get; set; }
        public UrunIcerik UrunIcerik { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
