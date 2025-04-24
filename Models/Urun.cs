using System.ComponentModel.DataAnnotations.Schema;

namespace YesilEvMVC.UI.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public int? BarkodNo { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriId { get; set; }
        public int UreticiId { get; set; }
        public int RenkId { get; set; }
        [NotMapped]
        public IFormFile OnYuzResmi { get; set; }
        [NotMapped]
        public IFormFile ArkaYuzResmi { get; set; }
        public string OnYuzResmiYolu { get; set; }
        public string ArkaYuzResmiYolu { get; set; }
        public int KullaniciId { get; set; }
        public Kategori Kategori { get; set; }
        public Kullanici Kullanici { get; set; }
        public Uretici Uretici { get; set; }
        public UrunRiskRenk UrunRiskRenk { get; set; }
        public ICollection<UrunIcerik> UrunIcerik { get; set; }
        public ICollection<UrunPaylas> UrunPaylas { get; set; }
        public ICollection<UrunIcerik> urunIcerik { get; set; }
    }
}
