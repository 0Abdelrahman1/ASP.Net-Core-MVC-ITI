using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowDetails(User user)
        {
            ViewBag.User = user;
            return View();
        }
    }
}
