using Wypozyczalnia.Models;

public class SprzetService : ISprzetService
{
    private readonly ISprzetRepository _repository;

    public SprzetService(ISprzetRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Sprzet> GetAllSprzet() => _repository.GetAll();
    public Sprzet GetSprzetById(int id) => _repository.GetById(id);
    public void AddSprzet(Sprzet sprzet) => _repository.Add(sprzet);
    public void UpdateSprzet(Sprzet sprzet) => _repository.Update(sprzet);
    public void DeleteSprzet(int id) => _repository.Delete(id);
}
