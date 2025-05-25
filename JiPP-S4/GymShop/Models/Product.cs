using System.ComponentModel.DataAnnotations;

namespace GymShop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

    }
}
