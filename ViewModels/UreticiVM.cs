using System.ComponentModel.DataAnnotations;

namespace YesilEvMVC.UI.ViewModels
{
    public class UreticiVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Üretici adı zorunludur.")]
        public string UreticiAdi { get; set; }
    }
}
