using DVUProject.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVUProject.Repositories.EFCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "phone",
                    Price = 30000,
                    Quantity = 10,
                    IsActive = true,

                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "television",
                    Price = 100000,
                    Quantity = 5,
                    IsActive = true,
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "computer",
                    Price = 25000,
                    Quantity = 8,
                    IsActive = true,

                });
                
        }
    }
}
