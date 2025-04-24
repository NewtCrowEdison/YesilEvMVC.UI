namespace YesilEvMVC.UI.Models
{
    public class UrunPaylas
    {
        public int Id { get; set; }
        public string PaylasmaTipi { get; set; }
        public ICollection<UrunPaylasKaydi> UrunPaylasKaydi { get; set; } = new List<UrunPaylasKaydi>();
    }
}
