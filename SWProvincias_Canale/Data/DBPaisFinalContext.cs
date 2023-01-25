using Microsoft.EntityFrameworkCore;
using SWProvincias_Canale.Models;

namespace SWProvincias_Canale.Data
{
    public class DBPaisFinalContext: DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options) { }
        // Propiedades
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
