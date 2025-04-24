namespace YesilEvMVC.UI.Models
{
    public class UrunIcerik
    {
        public int Id { get; set; }
        public string IcerikAdi { get; set; }
        public string Aciklama { get; set; }
        public ICollection<KullaniciKaraListe> KullaniciKaraListe { get; set; }
        public ICollection<UrunIcerikRisk> UrunIcerikRisk { get; set; }
    }
}
