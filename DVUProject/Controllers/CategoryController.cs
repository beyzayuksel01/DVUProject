using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DVUProject.Models.Entity;
using DVUProject.Models;
using DVUProject.Repositories.Contracts;

namespace DVUProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet("/Category/categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var categories = _categoryRepository.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpGet("/getCategory/{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            try
            {
                var category = _categoryRepository.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPost("/createCategory")]
        public ActionResult<Category> AddCategory([FromBody] Category category)
        {
            try
            {
                var createdCategory = _categoryRepository.AddCategory(category);
                return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }


        [HttpPut("/updateCategory/{id}")]
        public ActionResult<Category> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            try
            {
                var isUpdated = _categoryRepository.UpdateCategory(id, updatedCategory);

                if (isUpdated)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        [HttpDelete("/deleteCategory/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var isDeleted = _categoryRepository.DeleteCategory(id);

                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
