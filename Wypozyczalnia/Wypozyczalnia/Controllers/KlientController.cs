using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wypozyczalnia.Models;
using Wypozyczalnia.ViewModels;

public class KlientController : Controller
{
    private readonly IKlientService _service;
    private readonly IMapper _mapper;

    public KlientController(IKlientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var klienci = _service.GetAllKlienci();
        var vm = _mapper.Map<List<KlientViewModel>>(klienci);
        return View(vm);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(KlientViewModel model)
    {
        if (ModelState.IsValid)
        {
            var klient = _mapper.Map<Klient>(model);
            _service.AddKlient(klient);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public IActionResult Edit(int id)
    {
        var klient = _service.GetKlientById(id);
        if (klient == null) return NotFound();

        var model = _mapper.Map<KlientViewModel>(klient);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, KlientViewModel model)
    {
        if (id != model.Id_klient) return NotFound();

        if (ModelState.IsValid)
        {
            var klient = _mapper.Map<Klient>(model);
            _service.UpdateKlient(klient);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public IActionResult Delete(int id)
    {
        var klient = _service.GetKlientById(id);
        if (klient == null) return NotFound();

        var vm = _mapper.Map<KlientViewModel>(klient);
        return View(vm);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _service.DeleteKlient(id);
        return RedirectToAction(nameof(Index));
    }
}
