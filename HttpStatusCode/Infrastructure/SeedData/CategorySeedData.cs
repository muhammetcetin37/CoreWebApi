using HttpStatusCode.Models.DTOs.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HttpStatusCode.Infrastructure.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.HasData(
                new Category { Id = 1, Name = "Elektronik", Description = "Elektronik" },
                new Category { Id = 2, Name = "Tekstil", Description = "Tekstil" },
                new Category { Id = 3, Name = "Yiyecek", Description = "Yiyecek" },
                new Category { Id = 4, Name = "İçecek", Description = "İçecek" },
                new Category { Id = 5, Name = "Nalburiye", Description = "Nalburiye" });
        }
    }
}
