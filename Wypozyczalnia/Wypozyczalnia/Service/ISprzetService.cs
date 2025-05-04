using System.Collections.Generic;
using Wypozyczalnia.Models;

public interface ISprzetService
{
    IEnumerable<Sprzet> GetAllSprzet();
    Sprzet GetSprzetById(int id);
    void AddSprzet(Sprzet sprzet);
    void UpdateSprzet(Sprzet sprzet);
    void DeleteSprzet(int id);
}
