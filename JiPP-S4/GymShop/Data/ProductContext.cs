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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Whey Protein", ProductQuantity = 50, ProductPrice = 29.99 },
                new Product { ProductID = 2, ProductName = "Yoga Mat", ProductQuantity = 100, ProductPrice = 19.99 },
                new Product { ProductID = 3, ProductName = "Dumbbell Set", ProductQuantity = 20, ProductPrice = 89.99 },
                new Product { ProductID = 4, ProductName = "Resistance Bands", ProductQuantity = 75, ProductPrice = 14.99 },
                new Product { ProductID = 5, ProductName = "Kettlebell 16kg", ProductQuantity = 30, ProductPrice = 39.99 },
                new Product { ProductID = 6, ProductName = "Foam Roller", ProductQuantity = 60, ProductPrice = 24.99 },
                new Product { ProductID = 7, ProductName = "Jump Rope", ProductQuantity = 120, ProductPrice = 9.99 },
                new Product { ProductID = 8, ProductName = "Creatine Monohydrate", ProductQuantity = 40, ProductPrice = 19.49 }
            );
        }



    }


}
