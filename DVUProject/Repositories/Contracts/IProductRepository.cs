using System.Collections.Generic;
using DVUProject.Models;
using DVUProject.Models.Entity;

namespace DVUProject.Repositories.Contracts
{
    
        public interface IProductRepository 
        {
            IEnumerable<Product> GetAllProducts();
            Task<Product> GetProductByIdAsync(int id);
            Product AddProduct(Product product);
            void UpdateProduct(int productId,Product product);
            bool DeleteProduct(int productId);
    }
    
}
