using System.Collections.Generic;
using Wypozyczalnia.Models;

namespace Wypozyczalnia.Repositories
{
    public interface IKlientRepository
    {
        IEnumerable<Klient> GetAll();
        Klient GetById(int id);
        void Add(Klient klient);
        void Update(Klient klient);
        void Delete(int id);
        void Save();
    }
}
