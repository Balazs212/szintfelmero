using Microsoft.EntityFrameworkCore;
using Szintfelmero.Models;

namespace Szintfelmero.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<orszag> Orszagok { get; set; }
        public DbSet<szakma> Szakmak { get; set; }
        public DbSet<versenyzo> Versenyzok { get; set; }
    }
}
