using DVUProject.Models.Entity;

namespace DVUProject.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category AddCategory(Category category);
        bool UpdateCategory(int categoryId, Category updatedCategory);
        bool DeleteCategory(int categoryId);
    }
}
