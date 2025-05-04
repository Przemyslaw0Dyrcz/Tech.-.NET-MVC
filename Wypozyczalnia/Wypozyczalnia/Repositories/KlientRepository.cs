using System.Collections.Generic;
using System.Linq;
using Wypozyczalnia.Models;

namespace Wypozyczalnia.Repositories
{
    public class KlientRepository : IKlientRepository
    {
        private readonly AppDbContext _context;

        public KlientRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Klient> GetAll()
        {
            return _context.Klienci.ToList();
        }

        public Klient GetById(int id)
        {
            return _context.Klienci.Find(id);
        }

        public void Add(Klient klient)
        {
            _context.Klienci.Add(klient);
        }

        public void Update(Klient klient)
        {
            _context.Klienci.Update(klient);
        }

        public void Delete(int id)
        {
            var klient = _context.Klienci.Find(id);
            if (klient != null)
                _context.Klienci.Remove(klient);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
