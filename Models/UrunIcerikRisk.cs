namespace YesilEvMVC.UI.Models
{
    public class UrunIcerikRisk
    {
        public int Id { get; set; }
        public int IcerikId { get; set; }
        public int UrunRiskId { get; set; }
        public UrunIcerik Icerik { get; set; }
        public UrunRisk UrunRisk { get; set; }
    }
}
