using Wypozyczalnia.Models;

public interface IWypozyczenieRepository
{
    IEnumerable<Wypozyczenie> GetAll();
    Wypozyczenie GetById(int id);
    void Add(Wypozyczenie wypozyczenie);
    void Update(Wypozyczenie wypozyczenie);
    void Delete(int id);
}
