namespace YesilEvMVC.UI.Models
{
    public class KullaniciFavori
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int UrunId { get; set; }
        public int KullaniciId { get; set; }
        public Kategori Kategori { get; set; }
        public Urun Urun { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
