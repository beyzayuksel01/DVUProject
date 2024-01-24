using DVUProject.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVUProject.Repositories.EFCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                
                new Category
                {
                    Id=1,
                    Name="Teknoloji",
                    IsActive=true,

                }


                );
        }
    }
}
