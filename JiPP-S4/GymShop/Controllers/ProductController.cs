using GymShop.Repositories;
using GymShop.Data;
using GymShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GymShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager _productManager;    
        public ProductController(ProductContext context)
        {
            _productManager = new ProductManager(context);
        }

        public IActionResult Index()
        {
            var products = _productManager.GetAllProducts();
            return View(products);
        }

    }
}
