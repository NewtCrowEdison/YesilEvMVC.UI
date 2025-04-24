namespace YesilEvMVC.UI.Models
{
    public class KayitTipi
    {
        public int Id { get; set; }
        public string KayitAdi { get; set; }
        public ICollection<Kullanici> Kullanici { get; set; } = new List<Kullanici>();
    }
}
