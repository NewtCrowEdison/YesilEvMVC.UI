namespace YesilEvMVC.UI.Models
{
    public class ProgramIzin
    {
        public int Id { get; set; }
        public bool Kamera { get; set; } = false;
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
