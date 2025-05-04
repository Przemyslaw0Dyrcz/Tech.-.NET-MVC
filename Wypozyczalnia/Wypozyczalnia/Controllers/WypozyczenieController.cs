using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wypozyczalnia.Models;
using Wypozyczalnia.ViewModels;


public class WypozyczenieController : Controller
{
    private readonly IKlientService _klientService;
    private readonly ISprzetService _sprzetService;
    private readonly IWypozyczenieService _wypozyczenieService;

    public WypozyczenieController(
        IKlientService klientService,
        ISprzetService sprzetService,
        IWypozyczenieService wypozyczenieService)
    {
        _klientService = klientService;
        _sprzetService = sprzetService;
        _wypozyczenieService = wypozyczenieService;
    }

    public IActionResult Create()
    {
        var model = new WypozyczenieViewModel
        {
            Klienci = _klientService.GetAllKlienci().Select(k => new SelectListItem
            {
                Value = k.Id_klient.ToString(),
                Text = $"{k.Imie} {k.Nazwisko}"
            }),
            Sprzety = _sprzetService.GetAllSprzet().Select(s => new SelectListItem
            {
                Value = s.Id_sprzetu.ToString(),
                Text = $"{s.Producent} {s.Kategoria} ({s.Rozmiar})"
            }),
            Data_wypozyczenia = DateTime.Today
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(WypozyczenieViewModel model)
    {
        if (ModelState.IsValid)
        {
            var cenaZaTydzien = _sprzetService.GetSprzetById(model.Id_sprzetu).Cena_za_tydz;
            var dni = (model.Data_zwrotu.HasValue ? (model.Data_zwrotu.Value - model.Data_wypozyczenia).Days : 7);
            var cena = (dni <= 0 ? 7 : dni) * (cenaZaTydzien / 7); // Minimalnie tydzień

            var wypozyczenie = new Wypozyczenie
            {
                Id_klient = model.Id_klient,
                Id_sprzetu = model.Id_sprzetu,
                Data_wypozyczenia = model.Data_wypozyczenia,
                Data_zwrotu = model.Data_zwrotu,
                Cena_calkowita = decimal.Round(cena, 2)
            };

            _wypozyczenieService.AddWypozyczenie(wypozyczenie);
            return RedirectToAction("Index", "Klient");
        }

        model.Klienci = _klientService.GetAllKlienci().Select(k => new SelectListItem
        {
            Value = k.Id_klient.ToString(),
            Text = $"{k.Imie} {k.Nazwisko}"
        });

        model.Sprzety = _sprzetService.GetAllSprzet().Select(s => new SelectListItem
        {
            Value = s.Id_sprzetu.ToString(),
            Text = $"{s.Producent} {s.Kategoria} ({s.Rozmiar})"
        });

        return View(model);
    }
}
