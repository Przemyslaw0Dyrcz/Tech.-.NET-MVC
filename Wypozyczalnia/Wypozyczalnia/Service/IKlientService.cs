using Wypozyczalnia.Models;

public interface IKlientService
{
    IEnumerable<Klient> GetAllKlienci();
    Klient GetKlientById(int id);
    void AddKlient(Klient klient);
    void UpdateKlient(Klient klient);
    void DeleteKlient(int id);
}
