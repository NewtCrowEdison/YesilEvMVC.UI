namespace YesilEvMVC.UI.Models
{
    public class UrunPaylasKaydi
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }

        public int UrunId { get; set; }

        public int PaylasmaId { get; set; }

        public DateTime PaylasimTarihi { get; set; }

        public Kullanici Kullanici { get; set; }

        public UrunPaylas UrunPaylas { get; set; }

        public Urun Urun { get; set; }
    }
}
