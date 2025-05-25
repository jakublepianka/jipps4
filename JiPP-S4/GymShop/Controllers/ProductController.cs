using Microsoft.AspNetCore.Mvc;

namespace GymShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
