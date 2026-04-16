using Microsoft.AspNetCore.Mvc;
namespace Task.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ShowProductDetails(string Name = "Nokia", string Picture = "/img/nokia.png", double Price = 9.99, string Description = "UnBreakable")
        {
            ViewData["Name"] = Name;
            ViewData["Picture"] = Picture;
            ViewData["Price"] = $"{Price:0.00 $}";
            ViewData["Description"] = Description;
            return View("ProductDetails");
        }
    }
}
