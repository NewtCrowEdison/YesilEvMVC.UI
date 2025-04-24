using System.ComponentModel.DataAnnotations;

namespace YesilEvMVC.UI.Models
{
    public class UrunRiskRenk
    {
        public int Id { get; set; }
        public string Renk { get; set; }
        public ICollection<Urun> Urun { get; set; } = new List<Urun>();
    }
}
