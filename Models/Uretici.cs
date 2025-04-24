namespace YesilEvMVC.UI.Models
{
    public class Uretici
    {
        public int Id { get; set; }
        public string UreticiAdi { get; set; }
        public ICollection<Urun> Urun { get; set; }
    }
}