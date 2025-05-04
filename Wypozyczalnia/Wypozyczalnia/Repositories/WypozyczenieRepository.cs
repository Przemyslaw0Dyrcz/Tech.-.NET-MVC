using Microsoft.EntityFrameworkCore;
using Wypozyczalnia.Models;

public class WypozyczenieRepository : IWypozyczenieRepository
{
    private readonly AppDbContext _context;

    public WypozyczenieRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Wypozyczenie> GetAll()
        => _context.Wypozyczenia
            .Include(w => w.Klient)
            .Include(w => w.Sprzet)
            .ToList();

    public Wypozyczenie GetById(int id)
        => _context.Wypozyczenia
            .Include(w => w.Klient)
            .Include(w => w.Sprzet)
            .FirstOrDefault(w => w.Id_wypozyczenia == id);

    public void Add(Wypozyczenie wypozyczenie)
    {
        _context.Wypozyczenia.Add(wypozyczenie);
        _context.SaveChanges();
    }

    public void Update(Wypozyczenie wypozyczenie)
    {
        _context.Wypozyczenia.Update(wypozyczenie);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var wyp = _context.Wypozyczenia.Find(id);
        if (wyp != null)
        {
            _context.Wypozyczenia.Remove(wyp);
            _context.SaveChanges();
        }
    }
}
