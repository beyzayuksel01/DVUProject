using System.Collections.Generic;
using System.Linq;
using DVUProject.Models;
using DVUProject.Models.Entity;
using DVUProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;



namespace DVUProject.Repositories.EFCore.Config
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly RepositoryContext _context;
        public ProductRepository(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Where(x => x.IsActive == true).ToList();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await (from p in _context.Products
                                     join c in _context.Categories on
                                     p.CategoryId equals c.Id
                                     where p.Id == id && p.IsActive && c.IsActive
                                     select new Product
                                     {
                                         Id = p.Id,
                                         Name = p.Name,
                                         Price = p.Price,
                                         Quantity = p.Quantity,
                                         CategoryId = c.Id
                                     }).FirstOrDefaultAsync();

                return product;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in GetProductByIdAsync: {ex.Message}");

                throw;
            }
        }

        public Product AddProduct(Product product)
        {
            try
            {
                product.IsActive = true;
                _context.Products.Add(product);                
   
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public void UpdateProduct(int productId, Product product)
        {
            try
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.Name == product.Name);

                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Quantity = product.Quantity;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.IsActive = product.IsActive;

                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("The product to be updated could not be found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateProduct: {ex.Message}");

                throw;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var productToDelete = _context.Products.Find(productId);

                if (productToDelete == null)
                    return false;

                productToDelete.IsActive = false;
                _context.SaveChanges(); 

                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteProduct: {ex.Message}");
                return false;
            }
        }

    }
}
