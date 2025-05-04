using Wypozyczalnia.Models;
using Wypozyczalnia.Repositories;

public class KlientService : IKlientService
{
    private readonly IKlientRepository _repository;

    public KlientService(IKlientRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Klient> GetAllKlienci() => _repository.GetAll();
    public Klient GetKlientById(int id) => _repository.GetById(id);
    public void AddKlient(Klient klient)
    {
        klient.Data_rejestracja = DateTime.Now;
        _repository.Add(klient);
        _repository.Save();
    }

    public void UpdateKlient(Klient klient)
    {
        _repository.Update(klient);
        _repository.Save();
    }

    public void DeleteKlient(int id)
    {
        var klient = _repository.GetById(id);
        if (klient != null)
        {
            _repository.Delete(klient.Id_klient);
            _repository.Save();
        }
    }
}
