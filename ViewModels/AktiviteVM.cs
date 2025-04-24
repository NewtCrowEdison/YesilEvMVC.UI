using System.ComponentModel.DataAnnotations;

namespace YesilEvMVC.UI.ViewModels
{
    public class AktiviteVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Aktivite adı zorunludur.")]
        public string AktiviteAdi { get; set; }

        public int? AktivitePuani { get; set; }

        [Required(ErrorMessage = "Aktivite zamanı zorunludur.")]
        public DateTime AktiviteZamani { get; set; }
    }
}
