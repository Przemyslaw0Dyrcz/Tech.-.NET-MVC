using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wypozyczalnia.Models
{
    public class Wypozyczenie
    {
        [Key]
        public int Id_wypozyczenia { get; set; }
        public DateTime Data_wypozyczenia { get; set; }
        public DateTime? Data_zwrotu { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cena_calkowita { get; set; }
        public int Id_klient { get; set; }
        public Klient Klient { get; set; }
        public int Id_sprzetu { get; set; }
        public Sprzet Sprzet { get; set; }
    }
}
