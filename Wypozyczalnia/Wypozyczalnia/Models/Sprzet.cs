using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wypozyczalnia.Models
{
    public enum Kategoria
    {
        Narty,
        Buty,
        Kijki
    }

    public enum Producent
    {
        Atomic,
        Salomon,
        Head,
        Nordica,
        Volkl
    }

    public class Sprzet
    {
        [Key]
        public int Id_sprzetu { get; set; }
        public Kategoria Kategoria { get; set; }
        public Producent Producent { get; set; }
        public string Rozmiar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cena_za_tydz { get; set; }
        public ICollection<Wypozyczenie> Wypozyczenia { get; set; }

      

    }
}
