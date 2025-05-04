using System.Collections.Generic;
using Wypozyczalnia.Models;

public class WypozyczenieService : IWypozyczenieService
{
    private readonly IWypozyczenieRepository _repository;

    public WypozyczenieService(IWypozyczenieRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Wypozyczenie> GetAllWypozyczenia()
    {
        return _repository.GetAll();
    }

    public Wypozyczenie GetWypozyczenieById(int id)
    {
        return _repository.GetById(id);
    }

    public void AddWypozyczenie(Wypozyczenie wypozyczenie)
    {
        _repository.Add(wypozyczenie);
    }

    public void UpdateWypozyczenie(Wypozyczenie wypozyczenie)
    {
        _repository.Update(wypozyczenie);
    }

    public void DeleteWypozyczenie(int id)
    {
        _repository.Delete(id);
    }
}
