using DVUProject.Models;
using DVUProject.Models.Entity;
using DVUProject.Repositories.Contracts;

namespace DVUProject.Repositories.EFCore.Config
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RepositoryContext _context;

        public CategoryRepository(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.Where(x => x.IsActive == true).ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Where(x => x.Id == categoryId && x.IsActive == true).FirstOrDefault();
        }

        public Category AddCategory(Category category)
        {
            try
            {
                if (_context.Categories.Any(c => c.Name == category.Name))
                {
                    throw new InvalidOperationException("The category with the same name already exists.");
                }

                _context.Categories.Add(category);
                _context.SaveChanges();

                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddCategory: {ex.Message}");
                throw;

            }
        }

        public bool UpdateCategory(int categoryId, Category updatedCategory)
        {
            try
            {
                var categoryToUpdate = _context.Categories.Find(categoryId);

                if (categoryToUpdate == null)
                    return false;

                categoryToUpdate.Name = updatedCategory.Name;
                categoryToUpdate.IsActive = updatedCategory.IsActive;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateCategory: {ex.Message}");
                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var categoryToDelete = _context.Categories.Find(categoryId);

                if (categoryToDelete == null)
                    return false;

                categoryToDelete.IsActive = false;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteCategory: {ex.Message}");
                return false;
            }
        }
    }
}
