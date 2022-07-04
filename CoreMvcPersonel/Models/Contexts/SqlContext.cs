using CoreMvcPersonel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcPersonel.Models.Contexts
{
    public class SqlContext : DbContext
    {
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Fotograf> Fotograflar { get; set; }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
    }
}
