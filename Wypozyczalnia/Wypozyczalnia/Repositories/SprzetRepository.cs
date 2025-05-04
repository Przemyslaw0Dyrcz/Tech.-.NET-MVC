using Wypozyczalnia.Models;

public class SprzetRepository : ISprzetRepository
{
    private readonly AppDbContext _context;

    public SprzetRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Sprzet> GetAll() => _context.Sprzety.ToList();
    public Sprzet GetById(int id) => _context.Sprzety.Find(id);
    public void Add(Sprzet sprzet) { _context.Sprzety.Add(sprzet); _context.SaveChanges(); }
    public void Update(Sprzet sprzet) { _context.Sprzety.Update(sprzet); _context.SaveChanges(); }
    public void Delete(int id)
    {
        var sprzet = _context.Sprzety.Find(id);
        if (sprzet != null)
        {
            _context.Sprzety.Remove(sprzet);
            _context.SaveChanges();
        }
    }
}
