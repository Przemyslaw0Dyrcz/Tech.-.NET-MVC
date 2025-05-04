using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Wypozyczalnia.Models;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-8EP9S8L;Initial Catalog=WypozDB;Integrated Security=True;Trust Server Certificate=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}
