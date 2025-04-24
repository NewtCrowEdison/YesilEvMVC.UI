using System.ComponentModel.DataAnnotations;

namespace YesilEvMVC.UI.ViewModels
{
    public class KategoriVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        public string KategoriAdi { get; set; }
    }
}
