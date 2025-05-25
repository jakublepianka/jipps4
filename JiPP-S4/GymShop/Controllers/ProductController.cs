using GymShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace GymShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
