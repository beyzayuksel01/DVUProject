using System;
using System.Linq;
using System.Threading.Tasks;
using DVUProject.Models;
using DVUProject.Models.Entity;
using DVUProject.Repositories;
using DVUProject.Repositories.Contracts;
using DVUProject.Repositories.EFCore.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace DVUProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Index() 
        {
            var products = _productRepository.GetAllProducts().Where(p => p.IsActive).ToList();

            return View(products);
        }



        [HttpPost("/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.CreateProduct(product);
                _productRepository.Save();
                return RedirectToAction("Index");
            }
            return View(product); 
        }




        [HttpGet("/Product/products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpGet("/getProduct/{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPost("/createProduct")]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            try
            {
                var createdProduct = _productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut("/updateProduct/{id}")]
        public ActionResult<Product> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                _productRepository.UpdateProduct(id, updatedProduct);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }


        [HttpDelete("/delete/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var isDeleted = _productRepository.DeleteProduct(id);

                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


    }


}
