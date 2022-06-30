using HttpStatusCode.Infrastructure.SeedData;
using HttpStatusCode.Models.DTOs.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HttpStatusCode.Infrastructure.Contex
{
    public class SqlDbContext : DbContext
    {

        public SqlDbContext()
        {

        }
        public SqlDbContext(DbContextOptions<SqlDbContext> option) : base(option)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategorySeedData());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;Database=WebApiDb;User Id=sa;Password=123");
        }
    }
}
