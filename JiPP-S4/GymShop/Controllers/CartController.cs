using System.Text.Json;
using GymShop.Models;
using GymShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymShop.Controllers
{
    public class CartItem
    {
        public Product? Product { get; set; }
        public int ProductQuantity { get; set; }
    }
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddProduct(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Product?.ProductID == product.ProductID);
            if (item != null)
                item.ProductQuantity++;
            else
                Items.Add(new CartItem { Product = product, ProductQuantity = 1 });
        }

        public void RemoveProduct(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Product?.ProductID == productId);
            if (item != null)
                Items.Remove(item);
        }

        public double GetTotalPrice()
        {
            return Items.Sum(i => (double)(i.Product?.ProductPrice ?? 0) * i.ProductQuantity);
        }

        }
        
        public class CartController : Controller
        {
            private readonly ProductManager _productManager;

            public CartController(ProductManager productManager)
            {
                _productManager = productManager;
            }

            private Cart GetCart()
            {
                var cartJson = HttpContext.Session.GetString("Cart");
                if (cartJson != null)
                    return JsonSerializer.Deserialize<Cart>(cartJson) ?? new Cart();
                return new Cart();
            }

            private void SaveCart(Cart cart)
            {
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            }

            [HttpPost]
            public IActionResult AddToCart(int productId)
            {
                var product = _productManager.GetAllProducts().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                var cart = GetCart();
                var CartItem = cart.Items.FirstOrDefault(i => i.Product?.ProductID == productId);
                int currentQuantity = CartItem?.ProductQuantity ?? 0;
                if (currentQuantity >= product.ProductQuantity)
                {
                    TempData["Message"] = "Not enough items in stock to fulfill your request";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    cart.AddProduct(product);
                    SaveCart(cart);
                    return RedirectToAction("Index", "Product");
                }
                }
                return RedirectToAction("Index", "Product");

        }

        [HttpPost]
            public IActionResult RemoveFromCart(int productId)
            {
                var cart = GetCart();
                cart.RemoveProduct(productId);
                SaveCart(cart);

                return RedirectToAction("Cart");
            }

            [HttpPost]
            public IActionResult FinalizePurchase()
            {
                var cart = GetCart();
                foreach (var item in cart.Items)
                {
                    _productManager.DecreaseProductQuantity(item.Product.ProductID, item.ProductQuantity);
                }
                SaveCart(new Cart());
                TempData["Message"] = "Purchase finalized! Thank you for your order.";
                return RedirectToAction("Cart");
            }


            [HttpPost]
            public IActionResult ClearCart()
            {
                SaveCart(new Cart());
                TempData["Message"] = "Cart has been emptied.";
                return RedirectToAction("Cart");
            }

            public IActionResult Cart()
            {
                var cart = GetCart();
                return View("~/Views/Product/Cart.cshtml", cart);

        }

    }
}
