using System.ComponentModel.DataAnnotations;

namespace Wypozyczalnia.Models
{
    public class Klient
    {
        [Key]
        public int Id_klient { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(24, ErrorMessage = "Imię może mieć maksymalnie 24 znaki")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(30, ErrorMessage = "Nazwisko może mieć maksymalnie 30 znaków")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Telefon jest wymagany")]
        [Phone(ErrorMessage = "Wprowadź poprawny numer telefonu")]
        public string Telefon { get; set; }

        public DateTime Data_rejestracja { get; set; }

        public ICollection<Wypozyczenie> Wypozyczenia { get; set; } = new List<Wypozyczenie>();
    }
}
