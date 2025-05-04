using Wypozyczalnia.Models;

public interface ISprzetRepository
{
    IEnumerable<Sprzet> GetAll();
    Sprzet GetById(int id);
    void Add(Sprzet sprzet);
    void Update(Sprzet sprzet);
    void Delete(int id);
}
