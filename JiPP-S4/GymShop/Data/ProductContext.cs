using GymShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GymShop.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}
