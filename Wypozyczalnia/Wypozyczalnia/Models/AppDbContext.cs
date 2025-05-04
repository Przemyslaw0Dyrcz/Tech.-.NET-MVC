using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Wypozyczalnia.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>().HasKey(k => k.Id_klient);
            modelBuilder.Entity<Sprzet>().HasKey(s => s.Id_sprzetu);
            modelBuilder.Entity<Wypozyczenie>().HasKey(w => w.Id_wypozyczenia);
            base.OnModelCreating(modelBuilder);        
        }
    }

}
