using GymShop.Models;
using GymShop.Data;


namespace GymShop.Repositories
{
    public class ProductManager
    {
        private readonly ProductContext _context;

        public ProductManager(ProductContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public void DecreaseProductQuantity(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null && product.ProductQuantity >= quantity)
            {
                product.ProductQuantity -= quantity;
                _context.SaveChanges();
            }
        }
    }
}
