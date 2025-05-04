using Microsoft.AspNetCore.Mvc;
using Wypozyczalnia.Models;

namespace Wypozyczalnia.Controllers
{
    public class SprzetControlle1r : Controller
    {
        private AppDbContext _context;

            public SprzetControlle1r (AppDbContext dbcontext)
        {
            _context = dbcontext;
        }

    }
}
