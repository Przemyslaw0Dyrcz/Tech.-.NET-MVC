using System.Collections.Generic;
using Wypozyczalnia.Models;

public interface IWypozyczenieService
{
    IEnumerable<Wypozyczenie> GetAllWypozyczenia();
    Wypozyczenie GetWypozyczenieById(int id);
    void AddWypozyczenie(Wypozyczenie wypozyczenie);
    void UpdateWypozyczenie(Wypozyczenie wypozyczenie);
    void DeleteWypozyczenie(int id);
}
