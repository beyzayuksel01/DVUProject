using DVUProject.Models.Entity;
using DVUProject.Repositories.EFCore.Config;
using DVUProject.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using NJsonSchema.Validation;
using DVUProject.Models;
using System.Diagnostics;

namespace DVUProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}








//    {
//        public RepositoryContext _dataContext {  get; set; }
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult GetProducts()
//        {
//            using (_dataContext)
//            {
//                var products = _dataContext.Products.ToList();
//                return Json(products);
//            }
//        }
//        public void UpdateProduct(Product data)
//        {
//            using (_dataContext)
//            {
//                var product = _dataContext.Products.FirstOrDefault(p => p.Id == data.Id);

//                if (product != null)
//                {
//                    product.Name = data.Name;
//                    product.CategoryId = data.CategoryId;
//                    product.Price = data.Price;
//                    product.Quantity = data.Quantity;
//                    product.IsActive = data.IsActive;

//                    _dataContext.SaveChanges();
//                }
//            }
//        }

//        public JsonResult SaveProduct(Product data)
//        {
//            using (_dataContext)
//            {
//                _dataContext.Products.Add(data);
//                _dataContext.SaveChanges();
//            }

//            return (JsonResult)GetProducts();
//        }

//        public void DeleteProduct(int Id)
//        {
//            using (_dataContext)
//            {
//                var product = _dataContext.Products.FirstOrDefault(p => p.Id == Id);

//                if (product != null)
//                {
//                    _dataContext.Products.Remove(product);
//                    _dataContext.SaveChanges();
//                }
//            }
//        }
//        public ActionResult ProductIndex()
//        {

//            ViewData["Title"] = "Product List";
//            ViewData["EnteredData"] = TempData["EnteredData"] as List<string> ?? new List<string>();

//            return View();
//        }
//    }

//}
