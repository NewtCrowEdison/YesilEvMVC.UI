using System.ComponentModel.DataAnnotations;

namespace YesilEvMVC.UI.ViewModels
{
    public class UrunVM
    {
        public int Id { get; set; }
        [Required]
        public string UrunAdi { get; set; }
        public int? BarkodNo { get; set; }
        public int KategoriId { get; set; }
        public int UreticiId { get; set; }
        public IFormFile? OnYuzResmi { get; set; }
        public IFormFile? ArkaYuzResmi { get; set; }
    }
}
