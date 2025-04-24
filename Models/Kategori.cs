namespace YesilEvMVC.UI.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Urun> Urun { get; set; }
        public ICollection<UrunIcerik> UrunIcerik { get; set; }
    }
}
