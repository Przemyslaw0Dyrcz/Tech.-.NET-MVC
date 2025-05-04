using Microsoft.AspNetCore.Mvc.Rendering;

namespace Wypozyczalnia.ViewModels
{
    public class WypozyczenieViewModel
    {
        public int Id_klient { get; set; }
        public int Id_sprzetu { get; set; }

        public DateTime Data_wypozyczenia { get; set; }
        public DateTime? Data_zwrotu { get; set; }

        public decimal Cena_calkowita { get; set; }

        public IEnumerable<SelectListItem> Klienci { get; set; }
        public IEnumerable<SelectListItem> Sprzety { get; set; }
    }
}
