namespace YesilEvMVC.UI.Models
{
    public class UrunRisk
    {
        public int Id { get; set; }
        public string RiskAdi { get; set; }
        public ICollection<UrunIcerikRisk> UrunIcerikRisk { get; set; } = new List<UrunIcerikRisk>();
    }
}
