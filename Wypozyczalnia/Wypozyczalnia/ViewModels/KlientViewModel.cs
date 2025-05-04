using System.ComponentModel.DataAnnotations;

namespace Wypozyczalnia.ViewModels
{
    public class KlientViewModel
    {
        public int Id_klient { get; set; }

        [Required]
        [MaxLength(24)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nazwisko { get; set; }

        [Phone]
        [Required]
        public string Telefon { get; set; }

        public DateTime Data_rejestracja { get; set; }
    }
}
